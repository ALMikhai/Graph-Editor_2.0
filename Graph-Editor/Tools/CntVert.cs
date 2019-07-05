using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.Objects;

namespace Graph_Editor
{
    class CntVert : Tool
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

            if(vertexFirst != null)
            {
                if(vertexSecond == null)
                {
                    vertexSecond = vertexFirst;
                    vertexFirst = null;
                }
                else
                {
                    if (vertexFirst == vertexSecond || Globals.Matrix[vertexSecond.Index, vertexFirst.Index] >= 1 || Globals.Matrix[vertexFirst.Index, vertexSecond.Index] >= 1)
                    {
                        vertexFirst = null;
                        vertexSecond = null;
                    }
                    else
                    {
                        var edgeDirected = new Edge(vertexSecond, vertexFirst, 1, false);
                        var edgeUndirected = new Edge(vertexFirst, vertexSecond, 1, false);

                        Globals.Matrix[edgeDirected.From.Index, edgeDirected.To.Index] = 1;
                        Globals.Matrix[edgeDirected.To.Index, edgeDirected.From.Index] = 1;

                        Globals.EdgesData.Add(edgeDirected);
                        Globals.EdgesData.Add(edgeUndirected);

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
