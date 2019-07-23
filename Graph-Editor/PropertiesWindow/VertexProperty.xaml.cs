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
    public partial class VertexProperty : Window
    {
        public VertexProperty()
        {
            InitializeComponent();
        }

        public static void PropertiesVertexWindow(Vertex vertex)
        {
            VertexProperty propertyWindow = new VertexProperty();

            propertyWindow.nameVertex.Tag = vertex;

            propertyWindow.nameVertex.Text = (vertex.Text == "") ? vertex.Index.ToString() : vertex.Text;

            propertyWindow.nameVertex.TextChanged += NameVertex_TextChanged;

            foreach (var color in Globals.Colors)
            {
                Button newButton = new Button
                {
                    Height = 18,
                    Width = 18,
                    Background = color,
                    Tag = vertex,
                    Margin = new Thickness(2.5)
                };

                newButton.Click += ChangeColorVertex;

                propertyWindow.colorBar.Items.Add(newButton);
            }

            propertyWindow.ShowDialog();
        }

        private static void NameVertex_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vertex vertexBefor = new Vertex(((sender as TextBox).Tag as Vertex));

            ((sender as TextBox).Tag as Vertex).Text = (sender as TextBox).Text;

            History.Add(vertexBefor, new Vertex(((sender as TextBox).Tag as Vertex)));
            MainWindow.Instance.Invalidate();
        }

        private static void ChangeColorVertex(object sender, EventArgs e)
        {
            Vertex vertexBefor = new Vertex(((sender as Button).Tag as Vertex));

            ((sender as Button).Tag as Vertex).Color = (sender as Button).Background;

            History.Add(vertexBefor, new Vertex(((sender as Button).Tag as Vertex)));
            MainWindow.Instance.Invalidate();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
