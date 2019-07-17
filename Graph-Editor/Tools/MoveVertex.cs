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
	int forrepair;
        Point startPoint;
        Point finishPoint;

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
                    return;
                }
            }

            startPoint = pointNow;
        }

        public override void Mouse_Move(Point pointNow)
        {
            if(findedVertex != null)
            {
                findedVertex.Coordinates = pointNow;
                return;
            }

            if(startPoint != null)
            {
                finishPoint = pointNow;

                foreach(var vertex in Globals.VertexData)
                {
                    vertex.Coordinates = Point.Add(vertex.Coordinates, Point.Subtract(finishPoint, startPoint));
                }
            }

            startPoint = finishPoint;
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
