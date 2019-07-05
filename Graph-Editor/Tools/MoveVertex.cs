using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.Objects;

namespace Graph_Editor
{
    class MoveVertex : Tool
    {
        Vertex findedVertex;

        public override void Mouse_Down(Point pointNow)
        {
            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Coordinates.X - (Globals.VertRadius) <= pointNow.X &&
                    pointNow.X <= vertex.Coordinates.X + (Globals.VertRadius) &&
                    vertex.Coordinates.Y - (Globals.VertRadius) <= pointNow.Y &&
                    pointNow.Y <= vertex.Coordinates.Y + (Globals.VertRadius))
                {
                    findedVertex = vertex;
                    break;
                }
            }
        }

        public override void Mouse_Move(Point pointNow)
        {
            if(findedVertex != null)
            {
                findedVertex.Coordinates = pointNow;
            }
        }

        public override void Mouse_Up()
        {
            findedVertex = null;
        }

        public override void Change_Tool()
        {
            findedVertex = null;
        }
    }
}
