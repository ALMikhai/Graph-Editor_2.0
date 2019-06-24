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
        Vertex vertexFirst = null;
        Vertex findedVert = null;

        public override void Mouse_Down(Point pntNow)
        {
            foreach (Vertex vert in globals.vertexData)
            {
                if (vert.Coordinates.X - (globals.vertRadius) <= pntNow.X &&
                    pntNow.X <= vert.Coordinates.X + (globals.vertRadius) &&
                    vert.Coordinates.Y - (globals.vertRadius) <= pntNow.Y &&
                    pntNow.Y <= vert.Coordinates.Y + (globals.vertRadius))
                {
                    findedVert = vert;
                    break;
                }
            }

            if (findedVert != null)
            {
                if (vertexFirst == null)
                {
                    vertexFirst = findedVert;
                    findedVert = null;
                }
                else
                {
                    if (findedVert == vertexFirst)
                    {
                        findedVert = null;
                        vertexFirst = null;
                    }
                    else
                    {
                        foreach (Edge edge in globals.edgesData.ToArray())
                        {
                            if ((edge.From == vertexFirst && edge.To == findedVert) || (edge.From == findedVert && edge.To == vertexFirst))
                            {
                                globals.matrix[edge.From.Index, edge.To.Index] = 0;
                                if (!edge.Directed)
                                    globals.matrix[edge.To.Index, edge.From.Index] = 0;

                                globals.edgesData.Remove(edge);
                            }
                        }

                        findedVert = null;
                        vertexFirst = null;
                    }
                }

            }
        }

        public override void Change_Tool()
        {
            findedVert = null;
            vertexFirst = null;
        }
    }
}
