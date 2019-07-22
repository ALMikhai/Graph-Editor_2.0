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
        bool directedNow = false;

        private void ThemeSettings()
        {
            FullWindow.Background = Themes.ConnectMainWindow;

            FirstVertex.Background = Themes.ConnectWindowForVertex;
            SecondVertex.Background = Themes.ConnectWindowForVertex;

            WeightSlider.Background = Themes.ConnectSlider;
            TextBox_Weight.Background = Themes.ConnectSliderWindow;

            Create.Background = Themes.ConnectResultButtons;
            Close.Background = Themes.ConnectResultButtons;

            Undirected.Background = Themes.ConnectActiveOrientation;
            Directed.Background = Themes.ConnectUnactiveOrientation;
        }

        public ConnectVertices()
        {
            InitializeComponent();
            ThemeSettings();
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
                mainWindow.WaitPanel.Visibility = Visibility.Hidden;
            }
            mainWindow.Connect.IsEnabled = true;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Vertex from = new Vertex(), to = new Vertex();

            bool findFrom = false, findTo = false;

            if (FirstVertex.Text == "" || SecondVertex.Text == "" || TextBox_Weight.Text == "")
            {
                MessageBox.Show("ERROR!!!");
                return;
            }

            foreach (Vertex vertex in Globals.VertexData)
            {
                if (findFrom && findTo)
                {
                    break;
                }

                if (vertex.Index == Convert.ToInt32(FirstVertex.Text) && !findFrom)
                {
                    from = vertex;
                    findFrom = true;
                }

                else if (vertex.Index == Convert.ToInt32(SecondVertex.Text) && !findTo)
                {
                    to = vertex;
                    findTo = true;
                }
            }

            if (!findFrom || !findTo)
            {
                MessageBox.Show("ERROR!!!");
                return;
            }

            if (directedNow || (Globals.Matrix[to.Index, from.Index] == 0 && Globals.Matrix[from.Index, to.Index] == 0))
            {
                if (Globals.Matrix[from.Index, to.Index] >= 1)
                {
                    MessageBox.Show("You alredy have this edge!");
                    return;
                }

                CntVert.ConnectVertex(from, to, Convert.ToInt32(TextBox_Weight.Text), directedNow);

                MainWindow.Instance.Invalidate();

                // TODO Сделать выделение доп. память для матрицы.
                FirstVertex.Text = "";
                SecondVertex.Text = "";
                WeightSlider.Value = 1;
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
            {
                TextBox_Weight.Text = Math.Round(num).ToString();
            }
        }

        private void Directed_Button_Choose(object sender, RoutedEventArgs e)
        {
            directedNow = true;
            Undirected.Background = Themes.ConnectUnactiveOrientation;
            Directed.Background = Themes.ConnectActiveOrientation;
        }

        private void Undirected_Button_Choose(object sender, RoutedEventArgs e)
        {
            directedNow = false;
            Undirected.Background = Themes.ConnectActiveOrientation;
            Directed.Background = Themes.ConnectUnactiveOrientation;
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
            {
                (sender as Button).Background = Themes.ConnectUnactiveOrientationHover;
            }
        }

        private void DirecteMouseLeave(object sender, MouseEventArgs e)
        {
            if (String.Compare("#FF789778", (sender as Button).Background.ToString()) != 0)
            {
                (sender as Button).Background = Themes.ConnectUnactiveOrientation;
            }
        }
    }
}
