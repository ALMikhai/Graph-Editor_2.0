using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.Objects;

namespace Graph_Editor
{
    class DelEdge:Tool
    {
        Vertex vertexSecond = null;
        Vertex vertexFirst = null;

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
                }
                else
                {
                    if (vertexFirst == vertexSecond)
                    {
                        vertexFirst = null;
                        vertexSecond = null;
                    }
                    else
                    {
                        foreach (var edge in Globals.EdgesData.ToArray())
                        {
                            if ((edge.From == vertexSecond && edge.To == vertexFirst) || (edge.From == vertexFirst && edge.To == vertexSecond))
                            {
                                Globals.Matrix[edge.From.Index, edge.To.Index] = 0;

                                if (!edge.Directed)
                                {
                                    Globals.Matrix[edge.To.Index, edge.From.Index] = 0;
                                }

                                Globals.EdgesData.Remove(edge);
                            }
                        }

                        vertexFirst = null;
                        vertexSecond = null;
                    }
                }

            }
        }

        public override void Change_Tool()
        {
            vertexFirst = null;
            vertexSecond = null;
        }
    }
}
