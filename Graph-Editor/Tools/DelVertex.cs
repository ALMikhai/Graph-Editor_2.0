using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.Objects;
using Graph_Editor.UndoRedo;

namespace Graph_Editor
{
    class DelVertex : Tool
    {
        Vertex findedVert;

        public override void Mouse_Down(Point pointNow)
        {
            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Coordinates.X - (Globals.VertRadius) <= pointNow.X &&
                    pointNow.X <= vertex.Coordinates.X + (Globals.VertRadius) &&
                    vertex.Coordinates.Y - (Globals.VertRadius) <= pointNow.Y &&
                    pointNow.Y <= vertex.Coordinates.Y + (Globals.VertRadius))
                {
                    findedVert = vertex;
                    break;
                }
            }

            if(findedVert != null)
            {
                foreach (var edge in Globals.EdgesData.ToArray())
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

                for(var i = findedVert.Index; i < Globals.VertexData.Count; ++i)
                {
                    Globals.VertexData[i].Index--;
                }

                Globals.GlobalIndex--;

                Globals.RestoreMatrix();

                // TODO Добавлять в историю, до - вершина, после - лист интов с индексами вершин которые были связаны с этой.

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
