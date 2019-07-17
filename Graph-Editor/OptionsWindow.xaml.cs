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

namespace Graph_Editor
{
    public partial class OptionsWindow : Window
    {
        Brush vertexColor;
        Brush edgeColor;

        Button setNowVertex;
        Button setNowEdge;

        public OptionsWindow()
        {
            InitializeComponent();
        }
        private void ChangeVertexColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (setNowVertex != null)
                setNowVertex.Height = 25;
            else
                BaseVertex.Height = 25;

            vertexColor = (sender as Button).Background;

            setNowVertex = sender as Button;
            setNowVertex.Height = 30;
            /*Globals.ColorInsideVertex = (sender as Button).Background;*/
        }
        private void ChangeEdgeColorButton_Click(object sender, RoutedEventArgs e)
        {
            edgeColor = (sender as Button).Background;
           /*Globals.ColorEdge = (sender as Button).Background;*/
        }
    }
}
