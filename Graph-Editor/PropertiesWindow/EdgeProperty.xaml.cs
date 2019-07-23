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
using Graph_Editor.Objects;
using Graph_Editor.UndoRedo;

namespace Graph_Editor.PropertiesWindow
{
    public partial class EdgeProperty : Window
    {
        public EdgeProperty()
        {
            InitializeComponent();
        }

        public static void PropertiesEdgeWindow(Edge edge)
        {
            EdgeProperty propertyWindow = new EdgeProperty();

            propertyWindow.weightEdge.Text = edge.Weight.ToString();

            propertyWindow.weightEdge.Tag = edge;

            propertyWindow.weightEdge.TextChanged += weightEdge_TextChanged;

            foreach (var color in Globals.Colors)
            {
                Button newButton = new Button
                {
                    Height = 18,
                    Width = 18,
                    Background = color,
                    Tag = edge,
                    Margin = new Thickness(2.5)
                };

                newButton.Click += changeColorEdge;

                propertyWindow.colorBar.Items.Add(newButton);
            }
            
            propertyWindow.ShowDialog();
        }

        private static void weightEdge_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Edge edgeBefor = new Edge(((sender as TextBox).Tag as Edge));

                Edge edgeAfterDirected = ((sender as TextBox).Tag as Edge);

                if (!edgeAfterDirected.Directed)
                {
                    Edge edgeAfterUnDirected = Globals.FindReversEdge(edgeAfterDirected);
                    edgeAfterUnDirected.Weight = ((sender as TextBox).Text != "") ? Convert.ToInt32((sender as TextBox).Text) : 1;
                }

                edgeAfterDirected.Weight = ((sender as TextBox).Text != "") ? Convert.ToInt32((sender as TextBox).Text) : 1;

                Globals.RestoreMatrix();

                History.Add(edgeBefor, new Edge(edgeAfterDirected));
                MainWindow.Instance.Invalidate();
            }
            catch
            {

            }
        }

        private static void changeColorEdge(object sender, EventArgs e)
        {   
            Edge edgeBefor = new Edge(((sender as Button).Tag as Edge));

            Edge edgeAfterDirected = ((sender as Button).Tag as Edge);

            if (!edgeAfterDirected.Directed)
            {
                Edge edgeAfterUnDirected = Globals.FindReversEdge(edgeAfterDirected);
                edgeAfterUnDirected.Color = (sender as Button).Background;
            }

            edgeAfterDirected.Color = (sender as Button).Background;

            History.Add(edgeBefor, new Edge(edgeAfterDirected));
            MainWindow.Instance.Invalidate();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void weightEdge_KeyDown(object sender, KeyEventArgs e)
        {
            if(isDigit(e))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool isDigit(KeyEventArgs e)
        {
            if(e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 || e.Key == Key.D0 || e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
