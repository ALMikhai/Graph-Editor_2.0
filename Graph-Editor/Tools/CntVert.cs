using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Graph_Editor.Objects;
using Graph_Editor.UndoRedo;

namespace Graph_Editor
{
    class CntVert : Tool
    {
        Vertex vertexSecond = null;
        Vertex vertexFirst = null;

        Brush saveColor;

        public override void Mouse_Down(Point pointNow)
        {
            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Coordinates.X - (Globals.VertRadius) <= pointNow.X &&
                    pointNow.X <= vertex.Coordinates.X + (Globals.VertRadius) &&
                    vertex.Coordinates.Y - (Globals.VertRadius) <= pointNow.Y &&
                    pointNow.Y <= vertex.Coordinates.Y + (Globals.VertRadius))
                {
                    vertexFirst = vertex;
                    break;
                }
            }

            if(vertexFirst != null)
            {
                if(vertexSecond == null)
                {
                    vertexSecond = vertexFirst;
                    vertexFirst = null;

                    saveColor = vertexSecond.Color;
                    vertexSecond.Color = Brushes.Red;
                }
                else
                {
                    if (vertexFirst == vertexSecond || Globals.Matrix[vertexSecond.Index, vertexFirst.Index] >= 1 || Globals.Matrix[vertexFirst.Index, vertexSecond.Index] >= 1)
                    {
                        vertexSecond.Color = saveColor;
                        vertexFirst = null;
                        vertexSecond = null;
                    }
                    else
                    {
                        vertexSecond.Color = saveColor;
                        ConnectVertex(vertexFirst, vertexSecond, 1, false);

                        vertexFirst = null;
                        vertexSecond = null;
                    }
                }
            }
        }

        public static void ConnectVertex(Vertex from, Vertex to, int weight, bool directed)
        {
            if (Globals.Matrix[from.Index, to.Index] >= 1 || (Globals.Matrix[to.Index, from.Index] >= 1 && !directed))
            {
                return;
            }

            var edgeDirected = new Edge(from, to, weight, directed, OptionsWindow.settings.ColorEdge, Globals.ThicknessEdge);
            var edgeUndirected = new Edge(to, from, weight, directed, OptionsWindow.settings.ColorEdge, Globals.ThicknessEdge);

            Globals.EdgesData.Add(edgeDirected);
            Globals.Matrix[from.Index, to.Index] = weight;

            if (!directed)
            {
                Globals.EdgesData.Add(edgeUndirected);
                Globals.Matrix[to.Index, from.Index] = weight;
            }

            History.Add(null, new Edge(edgeDirected));
        }

        public override void Change_Tool()
        {
            if (vertexSecond != null)
            {
                vertexSecond.Color = saveColor;
            }
            saveColor = null;
            vertexFirst = null;
            vertexSecond = null;
        }
    }
}
