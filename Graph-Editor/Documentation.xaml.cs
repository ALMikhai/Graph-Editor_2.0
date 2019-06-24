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
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Documentation : Window
    {
        public Documentation()
        {
            InitializeComponent();
            forWhatAndWho.Text += "1) This program was created to demonstrate the work with graphs.\n\n" +
                "2) This application can be used by both students and teachers.";
            useOfIt.Text += "1) For students, this is the highest-quality presentation of information about working with graphs.\n\n" +
                "2) For teachers it is a chance, in the most understandable way for everyone, to thoroughly explain what a graph is, and most of its algorithms.";
            Instruct.Text += "We will start our ICON counting from top left to bottom. \n\n" +
                "1) Empty circle. With the tool selected, you can add vertices to a portion of the light blue color window, called the canvas.\n\n" +
                "2) The hand. With the selected tool, you can move the vertices without fear of accidentally adding a new vertex.\n\n" +
                "3) Circle with a cross inside. With the tool selected, you can delete the vertex and all edges connected to it.\n\n" +
                "4) Straight with a cross. With the tool selected, you can delete the edge by selecting 2 vertices.\n\n" +
                "5) Straight without a cross. With the tool selected, you can add the edge between 2 selected vertices";
        }

    }
}
