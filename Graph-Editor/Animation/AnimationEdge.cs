using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Graph_Editor.Objects;
using System.Drawing.Drawing2D;
using System.Windows.Media.Animation;
using System.Threading;
using System.Diagnostics;
using Graph_Editor.AlgoritmClasses;

namespace Graph_Editor
{
    static class AnimationEdge
    {
        public static Edge edge;

        public static Storyboard storyboard = new Storyboard
        {
            RepeatBehavior = new RepeatBehavior(1)
        };

        public static Ellipse ellipse = new Ellipse
        {
            Width = globals.vertRadius,
            Height = globals.vertRadius,
            Fill = Brushes.Blue
        };
        public static void Refresh_SrtoryBoard()
        {
            int time = 1;

            MainWindow.Instance.graphCanvas.Children.Add(ellipse);

            PathGeometry pathGeom = new PathGeometry();
            
            LineSegment vertLS = new LineSegment();
            PathFigure vertPF = new PathFigure();

            Point startPoint = Point.Add(edge.From.Coordinates, Point.Subtract(edge.From.Coordinates, new Point(edge.From.Coordinates.X + globals.vertRadius / 2, edge.From.Coordinates.Y + globals.vertRadius / 2)));
            Point finishPoint = Point.Add(edge.To.Coordinates, Point.Subtract(edge.To.Coordinates, new Point(edge.To.Coordinates.X + globals.vertRadius / 2, edge.To.Coordinates.Y + globals.vertRadius / 2)));

            vertPF.StartPoint = startPoint;
            vertLS.Point = finishPoint;

            vertPF.Segments.Add(vertLS);
            pathGeom.Figures.Add(vertPF);

            var moveCircleAnimation = new DoubleAnimationUsingPath
            {
                PathGeometry = pathGeom,
                Source = PathAnimationSource.X,
                Duration = TimeSpan.FromSeconds(time)
            };

            Storyboard.SetTarget(moveCircleAnimation, ellipse);
            Storyboard.SetTargetProperty(moveCircleAnimation, new PropertyPath("(Canvas.Left)"));

            var moveCircleAnimation2 = new DoubleAnimationUsingPath
            {
                PathGeometry = pathGeom,
                Source = PathAnimationSource.Y,
                Duration = TimeSpan.FromSeconds(time)
            };

            Storyboard.SetTarget(moveCircleAnimation2, ellipse);
            Storyboard.SetTargetProperty(moveCircleAnimation2, new PropertyPath("(Canvas.Top)"));

            storyboard.Children.Add(moveCircleAnimation);
            storyboard.Children.Add(moveCircleAnimation2);

            storyboard.Completed += Storyboard_Completed;
        }

        public static void Storyboard_Completed(object sender, EventArgs e)
        {
            
        }

        public static void NextAnimation(Edge e, List<Edge> edgesUsed)
        {
            edge = e;
            Refresh_SrtoryBoard();
            Start_animation();
            EventHandler callback = null;
            callback = (o, args) => {
                MainWindow.Instance.InvalidateAlgo(e);
                edgesUsed.Remove(edgesUsed[0]);
                storyboard.Completed -= callback;
                if (edgesUsed.Count > 0)
                {
                    storyboard.Children.Clear();
                    NextAnimation(edgesUsed[0], edgesUsed);
                }
            };
            storyboard.Completed += callback;
        }

        public static void Start_animation()
        {   
            storyboard.Begin();
        }
    }
}
