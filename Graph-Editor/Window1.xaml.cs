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
using System.ComponentModel; // CancelEventArgs

namespace Graph_Editor
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// 
    public partial class Window1 : Window
    {
        public static FigureHost graphHost = new FigureHost();
        bool route = false;
        public Window1()
        {
            InitializeComponent();
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.WaitPanel.Background = null;
            mainWindow.WaitPanel.Opacity = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

            globals.edgesData.Add(newEdge);
            if ((globals.matrix[newEdge.From.Index, newEdge.To.Index] != 1 && route) || (globals.matrix[newEdge.To.Index, newEdge.From.Index] != 1 && !route))
            {
                globals.matrix[newEdge.From.Index, newEdge.To.Index] = 1;
                if (!route)
                    globals.matrix[newEdge.To.Index, newEdge.From.Index] = 1;
            } else
            {
                MessageBox.Show("ERROR, YOU ALREDY HAVE THIS EDGE!!!");
                return;
            }

            MainWindow.Invalidate();



            //TODO Сделать выделение доп. память для матрицы

            this.Close();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double num = e.NewValue;
            ((Slider)sender).SelectionEnd = num;
            if (TextBox_Weight != null)
                TextBox_Weight.Text = Math.Round(num).ToString();
        }
        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            route = true;
        }
        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            route = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
    }
}
