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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Graph_Editor.Objects;
using System.ComponentModel;

namespace Graph_Editor
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// 
    public partial class ConnectVertices : Window
    {
        public static FigureHost graphHost = new FigureHost();
        bool route = false;
        public ConnectVertices()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FirstVertex.Focus();
        }
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            if (mainWindow != null && mainWindow.WaitPanel != null)
            {
                mainWindow.WaitPanel.Background = null;
                mainWindow.WaitPanel.Opacity = 0;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Vertex from = new Vertex(), to = new Vertex();

            bool findF = false, findS = false;

            if (FirstVertex.Text == "" || SecondVertex.Text == "" || TextBox_Weight.Text == "")
            {
                MessageBox.Show("ERROR!!!");
                return;
            }

            foreach (Vertex vertex in globals.vertexData)
            {
                if (findF && findS)
                    break;
                if (vertex.Index == Convert.ToInt32(FirstVertex.Text) && !findF)
                {
                    from = vertex;
                    findF = true;
                }

                else if (vertex.Index == Convert.ToInt32(SecondVertex.Text) && !findS)
                {
                    to = vertex;
                    findS = true;
                }
            }
            if (!findF || !findS)
            {
                MessageBox.Show("ERROR!!!");
                return;
            }

            Edge newEdge = new Edge(from, to, Convert.ToInt32(TextBox_Weight.Text), route);

            if (route || (globals.matrix[newEdge.To.Index, newEdge.From.Index] != 1 && globals.matrix[newEdge.From.Index, newEdge.To.Index] != 1))
            {
                if (globals.matrix[newEdge.From.Index, newEdge.To.Index] == 1)
                    MessageBox.Show("You alredy have this edge!");

                globals.edgesData.Add(newEdge);
                if (globals.matrix[newEdge.To.Index, newEdge.From.Index] == 1 && route)
                {
                    // TODO: Сделать красивый вывод рёбер.
                }

                globals.matrix[newEdge.From.Index, newEdge.To.Index] = 1;
                // TODO: Удалять нарисованное ребро (ориентированное) и добавлять обычное (неориентированное)
                if (!route)
                    globals.matrix[newEdge.To.Index, newEdge.From.Index] = 1;

                MainWindow.Instance.Invalidate();

                //TODO Сделать выделение доп. память для матрицы
                FirstVertex.Text = "";
                SecondVertex.Text = "";
                WeightSlider.Value = 0;
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double num = e.NewValue;
            ((Slider)sender).SelectionEnd = num;
            if (TextBox_Weight != null)
                TextBox_Weight.Text = Math.Round(num).ToString();
        }
        private void Directed_Button_Choose(object sender, RoutedEventArgs e)
        {
            route = true;
            Undirected.Background = (Brush)new BrushConverter().ConvertFrom("#98B0B0");
            Directed.Background = (Brush)new BrushConverter().ConvertFrom("#789778");
        }
        private void Undirected_Button_Choose(object sender, RoutedEventArgs e)
        {
            route = false;
            Undirected.Background = (Brush)new BrushConverter().ConvertFrom("#789778");
            Directed.Background = (Brush)new BrushConverter().ConvertFrom("#98B0B0");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_Weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox_Weight.Text != "")
            {
                int point = Convert.ToInt32(TextBox_Weight.Text);
                WeightSlider.SelectionEnd = point;
                WeightSlider.Value = point;
            }
        }

        private void DirecteMouseMove(object sender, MouseEventArgs e)
        {
            if (String.Compare("#FF789778", (sender as Button).Background.ToString()) != 0)
                (sender as Button).Background = (Brush)new BrushConverter().ConvertFrom("#BCCBBC");
        }

        private void DirecteMouseLeave(object sender, MouseEventArgs e)
        {
            if (String.Compare("#FF789778", (sender as Button).Background.ToString()) != 0)
                (sender as Button).Background = (Brush)new BrushConverter().ConvertFrom("#98B0B0");
        }
    }
}
