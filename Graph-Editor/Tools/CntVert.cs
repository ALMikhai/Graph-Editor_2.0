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

            if(findedVert != null)
            {
                if(vertexFirst == null)
                {
                    vertexFirst = findedVert;
                    findedVert = null;
                }
                else
                {
                    if (findedVert == vertexFirst || globals.matrix[vertexFirst.Index, findedVert.Index] == 1 || globals.matrix[findedVert.Index, vertexFirst.Index] == 1)
                    {
                        findedVert = null;
                        vertexFirst = null;
                    }
                    else
                    {
                        Edge edge = new Edge(vertexFirst, findedVert, 1, false);
                        Edge edge1 = new Edge(findedVert, vertexFirst, 1, false);
                        globals.matrix[edge.From.Index, edge.To.Index] = 1;
                        globals.matrix[edge.To.Index, edge.From.Index] = 1;

                        globals.edgesData.Add(edge);
                        globals.edgesData.Add(edge1);

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
