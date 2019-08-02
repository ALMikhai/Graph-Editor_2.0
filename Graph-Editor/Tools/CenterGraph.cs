using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.UndoRedo;

namespace Graph_Editor
{
    public static class CenterGraph
    {
        public static void MoveGraph(object s, RoutedEventArgs e)
        {
            if (Globals.AnimationsNow.Count != 0)
            {
                return;
            }
            try
            {
                double topBorder = Globals.VertexData[0].Coordinates.Y;
                double bottomBorder = Globals.VertexData[0].Coordinates.Y;
                double leftBorder = Globals.VertexData[0].Coordinates.X;
                double rightBorder = Globals.VertexData[0].Coordinates.X;

                foreach (var vertex in Globals.VertexData)
                {
                    if (vertex.Coordinates.Y > bottomBorder)
                    {
                        bottomBorder = vertex.Coordinates.Y;
                    }
                    if (vertex.Coordinates.Y < topBorder)
                    {
                        topBorder = vertex.Coordinates.Y;
                    }
                    if (vertex.Coordinates.X > rightBorder)
                    {
                        rightBorder = vertex.Coordinates.X;
                    }
                    if (vertex.Coordinates.X < leftBorder)
                    {
                        leftBorder = vertex.Coordinates.X;
                    }
                }

                double centerX = ((rightBorder - leftBorder) / 2) + leftBorder;
                double centerY = ((bottomBorder - topBorder) / 2) + topBorder;

                Point centerGraph = new Point(centerX, centerY);
                Point centerCanvas = new Point(MainWindow.Instance.GraphCanvas.ActualWidth / 2, MainWindow.Instance.GraphCanvas.ActualHeight / 2);

                Vector vector = Point.Subtract(centerCanvas, centerGraph);

                foreach (var vertex in Globals.VertexData)
                {
                    vertex.Coordinates = Point.Add(vertex.Coordinates, vector);
                }

                List<Point> startPoints = new List<Point>();
                startPoints.Add(centerGraph);

                List<Point> finishPoints = new List<Point>();
                finishPoints.Add(centerCanvas);

                History.Add(startPoints, finishPoints);

                MainWindow.Instance.Invalidate();
            }
            catch
            {
                
            }
        }
    }
}
