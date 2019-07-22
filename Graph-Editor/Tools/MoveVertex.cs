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
    class MoveVertex : Tool
    {
        Vertex startPositionVertex;
        Vertex finishPositionVertex;

        //Point startPoint;
        //Point finishPoint;

        public override void Mouse_Down(Point pointNow)
        {
            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Coordinates.X - (Globals.VertRadius) <= pointNow.X &&
                    pointNow.X <= vertex.Coordinates.X + (Globals.VertRadius) &&
                    vertex.Coordinates.Y - (Globals.VertRadius) <= pointNow.Y &&
                    pointNow.Y <= vertex.Coordinates.Y + (Globals.VertRadius))
                {
                    startPositionVertex = new Vertex(vertex);
                    finishPositionVertex = vertex;
                    return;
                }
            }

            //startPoint = pointNow;
        }

        public override void Mouse_Move(Point pointNow)
        {
            if(startPositionVertex != null)
            {
                finishPositionVertex.Coordinates = pointNow;
                return;
            }

            //if(startPoint != null)
            //{
            //    finishPoint = pointNow;

            //    foreach(var vertex in Globals.VertexData)
            //    {
            //        vertex.Coordinates = Point.Add(vertex.Coordinates, Point.Subtract(finishPoint, startPoint));
            //    }
            //}

            //startPoint = finishPoint;
        }

        public override void Mouse_Up()
        {
            if (startPositionVertex != null && finishPositionVertex != null)
            {
                History.Add(new Vertex(startPositionVertex), new Vertex(finishPositionVertex));
            }
            startPositionVertex = null;
            finishPositionVertex = null;
        }

        public override void Change_Tool()
        {
            startPositionVertex = null;
            finishPositionVertex = null;
        }
    }
}
