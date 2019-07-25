using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Objects;
using System.Windows;
using Graph_Editor.UndoRedo;

namespace Graph_Editor
{
    public static class ResizeGraph
    {
        static double step = 5;

        public static void IncreaseCanvas(double heightCanvas, double widthCanvas)
        {
            addToHistory();

            double AbstractHeight = ((heightCanvas * (100 + step)) / 100);
            double AbstractWidth = ((widthCanvas * (100 + step)) / 100);

            double heightScale = AbstractHeight / heightCanvas;
            double widthScale = AbstractWidth / widthCanvas;

            foreach (var vertex in Globals.VertexData.ToArray())
            {
                vertex.Coordinates = new Point(vertex.Coordinates.X * widthScale, vertex.Coordinates.Y * heightScale);
            }
        }

        public static void DecreaseCanvas(double heightCanvas, double widthCanvas)
        {
            addToHistory();

            double AbstractHeight = ((heightCanvas * (100 - step)) / 100);
            double AbstractWidth = ((widthCanvas * (100 - step)) / 100);

            double heightScale = AbstractHeight / heightCanvas;
            double widthScale = AbstractWidth / widthCanvas;

            foreach(var vertex in Globals.VertexData.ToArray())
            {
                vertex.Coordinates = new Point(vertex.Coordinates.X * widthScale, vertex.Coordinates.Y * heightScale);
            }
        }

        private static void addToHistory()
        {
            if(History.records[History.numberRecords - 1].Checker != 1)
            {
                List<Vertex> vertices = new List<Vertex>();

                foreach(var vert in Globals.VertexData)
                {
                    vertices.Add(new Vertex(vert));
                }

                List<Edge> edges = new List<Edge>();

                foreach(var edge in Globals.EdgesData)
                {
                    edges.Add(new Edge(edge));
                }

                History.Add(vertices, edges, 1);
            }
        }
    }
}
