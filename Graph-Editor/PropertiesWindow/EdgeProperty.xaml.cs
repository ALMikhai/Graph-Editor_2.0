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

                newButton.Click += ChangeColorEdge;

                propertyWindow.colorBar.Items.Add(newButton);
            }
            
            propertyWindow.ShowDialog();
        }

        private static void weightEdge_TextChanged(object sender, TextChangedEventArgs e)
        {
            Edge edgeBefor = new Edge(((sender as TextBox).Tag as Edge));

            Edge edgeAfterDirected = ((sender as TextBox).Tag as Edge);

            if (!edgeAfterDirected.Directed)
            {
                Edge edgeAfterUnDirected = Globals.FindReversEdge(edgeAfterDirected);
                edgeAfterUnDirected.Weight = Convert.ToInt32((sender as TextBox).Text);
            }

            edgeAfterDirected.Weight = Convert.ToInt32((sender as TextBox).Text);

            Globals.RestoreMatrix();

            History.Add(edgeBefor, new Edge(edgeAfterDirected));
            MainWindow.Instance.Invalidate();
        }

        private static void ChangeColorEdge(object sender, EventArgs e)
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

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
