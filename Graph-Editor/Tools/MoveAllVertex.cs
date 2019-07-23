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
    class MoveAllVertex : Tool
    {
        Point startPoint;
        Point finishPoint;

        Point globalStartPoint;
        Point globalFinishPoint;

        public override void Mouse_Down(Point pointNow)
        {
            startPoint = pointNow;
            globalStartPoint = pointNow;
        }

        public override void Mouse_Move(Point pointNow)
        {
            if (startPoint != null)
            {
                finishPoint = pointNow;

                foreach (var vertex in Globals.VertexData)
                {
                    vertex.Coordinates = Point.Add(vertex.Coordinates, Point.Subtract(finishPoint, startPoint));
                }
            }

            startPoint = finishPoint;
            globalFinishPoint = pointNow;
        }

        public override void Mouse_Up()
        {
            List<Point> startPoints = new List<Point>();
            startPoints.Add(globalStartPoint);

            List<Point> finishPoints = new List<Point>();
            finishPoints.Add(globalFinishPoint);

            History.Add(startPoints, finishPoints);

            startPoint = new Point();
            finishPoint = new Point();

            globalStartPoint = new Point();
            globalFinishPoint = new Point();
        }

        public override void Change_Tool()
        {
            startPoint = new Point();
            finishPoint = new Point();

            globalStartPoint = new Point();
            globalFinishPoint = new Point();
        }
    }
}
