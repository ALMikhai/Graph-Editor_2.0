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
using System.Drawing.Drawing2D;
using System.Windows.Media.Animation;
using System.Threading;
using System.Diagnostics;
using Graph_Editor.Algoritms;


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

        //public static Brush ColorInsideVertex = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        //public static Brush ColorEdge = Brushes.Black;
        public static double ThicknessEdge = 1;

        public static Ellipse AnimationEllipse = new Ellipse
        {
            Width = VertRadius,
            Height = VertRadius,
            Fill = Settings.AnimationEllipseColor
        };

        public static Dictionary<int, Tool> ToolList = new Dictionary<int, Tool>
        {
            {0, new  AddVertex()},
            {1, new  MoveVertex()},
            {2, new  DelVertex()},
            {3, new CntVert()},
            {4, new DelEdge()}
        };
        public static Dictionary<int, Algoritm> AlgoList = new Dictionary<int, Algoritm>
        {
            {0, new Bfs()},
            {1, new Dfs()},
            {2, new Dijkstra()},
            {5, new Euler()},
            {6, new Floyd()},
            {7, new Kruskal()}
        };

        public static List<Brush> Colors = new List<Brush>
        {
            {(Brush)new BrushConverter().ConvertFrom("#80FFFF")},
            {(Brush)new BrushConverter().ConvertFrom("#A0ECFF")},
            {(Brush)new BrushConverter().ConvertFrom("#FBCD6B")},
            {(Brush)new BrushConverter().ConvertFrom("#BE88DC")},
            {(Brush)new BrushConverter().ConvertFrom("#EA6461")}
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
                Matrix[edge.From.Index, edge.To.Index] = edge.Weight;
                if (!edge.Directed)
                {
                    Matrix[edge.To.Index, edge.From.Index] = edge.Weight;
                }
            }
        }

        public static Vertex FindVertex(Vertex vertex)
        {
            return VertexData.Find(match => (match.Index == vertex.Index
                                                  && match.Coordinates == vertex.Coordinates
                                                  && match.Color == vertex.Color));
        }

        public static Edge FindEdge(Edge edge)
        {
            return EdgesData.Find(match => (match.From == FindVertex(edge.From) && match.To == FindVertex(edge.To)));
        }

        public static Edge FindReversEdge(Edge edge)
        {
            return EdgesData.Find(match => (match.From == FindVertex(edge.To) && match.To == FindVertex(edge.From)));
        }
    }
}
