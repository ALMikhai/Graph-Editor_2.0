using System;
using System.Collections.Generic;
using System.Windows.Media;
using Graph_Editor.Objects;


namespace Graph_Editor
{
    [Serializable]
    public static class Globals
    {
        public static int GlobalIndex = 0;
        public static int Size = 100;
        public static int[,] Matrix = new int[Size, Size];
        public static List<Vertex> VertexData = new List<Vertex>();
        public static List<Edge> EdgesData = new List<Edge>();

        public static Pen BasePen = new Pen(Brushes.Black, 1);
        public static Pen AlgoPen = new Pen(Brushes.Red, 2);
        public static int VertRadius = 20;
        
        public static Brush ColorInsideVertex = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        public static Brush ColorEdge = Brushes.Black;
        public static double ThicknessEdge = 1;


        public static Dictionary<int, Tool> ToolList = new Dictionary<int, Tool>
        {
            {0, new  AddVertex()},
            {1, new  MoveVertex()},
            {2, new  DelVertex()},
            {3, new CntVert()},
            {4, new DelEdge()}
        };

        public static Tool ToolNow = ToolList[0];

        public static bool IsBe(int value)
        {
            foreach (var vertex in VertexData)
            {
                if (value == vertex.Index)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckIn(int v)
        {
            int i;

            for (i = 0; i < Size; i++)
            {
                if (Matrix[v, i] != 0)
                    break;
            }

            if (i == Size)
            {
                return false;
            }

            return true;
        }

        public static bool CheckDirected()
        {
            foreach(var edge in EdgesData)
            {
                if(edge.Directed)
                {
                    return true;
                }
            }
            return false;
            
        }

        public static void RestoreMatrix()
        {
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    Matrix[i, j] = 0;
                }
            }

            foreach (var edge in EdgesData)
            {
                Matrix[edge.From.Index, edge.To.Index] = 1;
                if (!edge.Directed)
                {
                    Matrix[edge.To.Index, edge.From.Index] = 1;
                }
            }
        }
    }
}
