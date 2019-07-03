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
        Vertex vertexFirst = null;
        Vertex findedVert = null;

        public override void Mouse_Down(Point pntNow)
        {
            foreach (Vertex vert in Globals.VertexData)
            {
                if (vert.Coordinates.X - (Globals.VertRadius) <= pntNow.X &&
                    pntNow.X <= vert.Coordinates.X + (Globals.VertRadius) &&
                    vert.Coordinates.Y - (Globals.VertRadius) <= pntNow.Y &&
                    pntNow.Y <= vert.Coordinates.Y + (Globals.VertRadius))
                {
                    findedVert = vert;
                    break;
                }
            }

            if(findedVert != null)
            {
                if(vertexFirst == null)
                {
                    vertexFirst = findedVert;
                    findedVert = null;
                }
                else
                {
                    if (findedVert == vertexFirst || Globals.Matrix[vertexFirst.Index, findedVert.Index] == 1 || Globals.Matrix[findedVert.Index, vertexFirst.Index] == 1)
                    {
                        findedVert = null;
                        vertexFirst = null;
                    }
                    else
                    {
                        Edge edge = new Edge(vertexFirst, findedVert, 1, false);
                        Edge edge1 = new Edge(findedVert, vertexFirst, 1, false);
                        Globals.Matrix[edge.From.Index, edge.To.Index] = 1;
                        Globals.Matrix[edge.To.Index, edge.From.Index] = 1;

                        Globals.EdgesData.Add(edge);
                        Globals.EdgesData.Add(edge1);

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
