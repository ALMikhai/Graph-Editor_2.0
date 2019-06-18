using Graph_Editor.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace Graph_Editor
{
    public class globals
    {

        public static int[,] matrix = new int[100, 100];
        public static List<Vertex> vertexData = new List<Vertex>();
        public static List<Edge> edgesData = new List<Edge>();
    }
}
