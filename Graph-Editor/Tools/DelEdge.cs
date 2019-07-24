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
    class DelEdge:Tool
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

            if (vertexFirst != null)
            {
                if (vertexSecond == null)
                {
                    vertexSecond = vertexFirst;
                    vertexFirst = null;

                    saveColor = vertexSecond.Color;
                    vertexSecond.Color = Brushes.Red;
                }
                else
                {
                    if (vertexFirst == vertexSecond)
                    {
                        vertexSecond.Color = saveColor;
                        vertexFirst = null;
                        vertexSecond = null;
                    }
                    else
                    {
                        vertexSecond.Color = saveColor;

                        Edge directedEdge = Globals.EdgesData.Find(match => (match.From == vertexSecond && match.To == vertexFirst));

                        if (directedEdge != null)
                        {
                            if (!directedEdge.Directed)
                            {
                                Edge unDirectedEdge = Globals.EdgesData.Find(match => (match.From == vertexFirst && match.To == vertexSecond));
                                Globals.EdgesData.Remove(unDirectedEdge);
                            }

                            History.Add(new Edge(directedEdge), null);

                            Globals.EdgesData.Remove(directedEdge);

                            Globals.RestoreMatrix();
                        }
                        vertexFirst = null;
                        vertexSecond = null;
                    }
                }

            }
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
