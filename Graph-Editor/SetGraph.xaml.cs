using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Graph_Editor.Objects;
using Graph_Editor.UndoRedo;


namespace Graph_Editor
{
    public partial class SetGraph : Window
    {
        private void ThemeSettings()
        {
            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();

            logo.Source = bitmap;

            fullWindow.Background = Themes.SetGraphMainWindow;

            Clear.Background = Themes.SetGraphButtons;
            Cancel.Background = Themes.SetGraphButtons;
            Save.Background = Themes.SetGraphButtons;

            Parametrs.Background = Themes.SetGraphTextBox;

        }

        public SetGraph()
        {
            InitializeComponent();

            ThemeSettings();

            Instructions.Text = "Style of code: \nFirst Number of vertices\nSecond Number of edges\nThird Index of the first vertex_index of the second vertex_weight of the edge";
        }

        private void Parametrs_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Parametrs.Text += '\n';
                return;
            }

            if (PropertiesWindow.EdgeProperty.isDigit(e))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Parametrs.Text = "";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        string path = "../../SaveLoad/buffer.bin";

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Parametrs.Text == "")
            {
                return;
            }

            StreamWriter writer = new StreamWriter(path, false, Encoding.Default);

            writer.Write(Parametrs.Text);

            writer.Close();

            StreamReader reader = new StreamReader(path, Encoding.Default);

            try
            {    
                string number = reader.ReadLine();

                int numberVertices = Convert.ToInt32(number);

                if(numberVertices == 0)
                {
                    return;
                }

                Globals.GlobalIndex = numberVertices;

                MainWindow.Instance.ClearAll_Click(new object(), new RoutedEventArgs());

                Random random = new Random(DateTime.Now.Millisecond * DateTime.Now.Minute);

                for (var i = 0; i < numberVertices; ++i)
                {
                    Point place = new Point(random.Next(0 + Globals.VertRadius, (int)MainWindow.Instance.GraphCanvas.ActualWidth - Globals.VertRadius), random.Next(0 + Globals.VertRadius, (int)MainWindow.Instance.GraphCanvas.ActualHeight - Globals.VertRadius));
                    Globals.VertexData.Add(new Vertex(i, place));
                }

                number = reader.ReadLine();

                int numerEdges = Convert.ToInt32(number);
                
                for (var i = 0; i < numerEdges; ++i)
                {
                    number = reader.ReadLine();

                    string[] fromToWeight = number.Split(' ');

                    Globals.EdgesData.Add(new Edge(Globals.VertexData.Find(match => match.Index == Convert.ToInt32(fromToWeight[0])), Globals.VertexData.Find(match => match.Index == Convert.ToInt32(fromToWeight[1])), Convert.ToInt32(fromToWeight[2]), true, OptionsWindow.settings.ColorEdge, Globals.ThicknessEdge));
                }

                reader.Close();

                Globals.RestoreMatrix();

                foreach(var edge in Globals.EdgesData)
                {
                    if(edge.Directed && Globals.Matrix[edge.To.Index, edge.From.Index] == Globals.Matrix[edge.From.Index, edge.To.Index])
                    {
                        edge.Directed = false;
                        (Globals.EdgesData.Find(match => (match.To.Index == edge.From.Index) && (match.From.Index == edge.To.Index))).Directed = false;
                    }
                }

                MainWindow.Instance.Invalidate();

                List<Vertex> vertices = new List<Vertex>();
                foreach (var vertex in Globals.VertexData)
                {
                    vertices.Add(new Vertex(vertex));
                }

                List<Edge> edges = new List<Edge>();
                foreach (var edge in Globals.EdgesData)
                {
                    edges.Add(new Edge(edge));
                }

                History.Add(edges, vertices);
            }
            catch
            {
                Globals.VertexData.Clear();
                Globals.EdgesData.Clear();
                Globals.GlobalIndex = 0;
                reader.Close();
                System.Windows.MessageBox.Show("Invalid input graph format.");
            }
        }
    }
}
