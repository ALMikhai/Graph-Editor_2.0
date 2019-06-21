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
    public static class globals
    {
        public static int globalIndex = 0;
        public static int[,] matrix = new int[100, 100];
        public static List<Vertex> vertexData = new List<Vertex>();
        public static List<Edge> edgesData = new List<Edge>();

        public static int vertRadius = 20;

        public static Dictionary<int, Tool> toolList = new Dictionary<int, Tool>
        {
            {0, new  AddVertex()},
            {1, new  MoveVertex()},
        };

        public static Tool toolNow = toolList[0];
    }
}
