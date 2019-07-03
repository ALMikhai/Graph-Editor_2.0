using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.Objects;

namespace Graph_Editor
{
    class DelVertex : Tool
    {
        Vertex findedVert;

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
                foreach (Edge edge in Globals.EdgesData.ToArray())
                {
                    if (edge.From == findedVert || edge.To == findedVert)
                    {
                        Globals.Matrix[edge.From.Index, edge.To.Index] = 0;
                        if (!edge.Directed)
                        {
                            Globals.Matrix[edge.To.Index, edge.From.Index] = 0;
                        }
                        Globals.EdgesData.Remove(edge);
                    }
                }

                

                Globals.VertexData.Remove(findedVert);

                findedVert = null;
            }
        }

        public override void Change_Tool()
        {
            findedVert = null;
        }
    }
}
