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
                List<Edge> adjacentVertices = new List<Edge>();

                foreach (var edge in Globals.EdgesData.ToArray())
                {
                    if (edge.From == findedVert || edge.To == findedVert)
                    {
                        adjacentVertices.Add(new Edge(edge));

                        Globals.EdgesData.Remove(edge);
                    }
                }

                History.Add(new Vertex(findedVert), adjacentVertices);

                foreach(var vertex in Globals.VertexData)
                {
                    if(vertex.Index >= findedVert.Index && vertex != findedVert)
                    {
                        vertex.Index--;
                    }
                }

                Globals.RestoreMatrix();

                Globals.GlobalIndex--;

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
