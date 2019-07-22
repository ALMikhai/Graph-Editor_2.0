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
using Graph_Editor.Algoritms;

namespace Graph_Editor
{
    static class AnimationEdge
    {
        private static Edge animatedEdge;

        private static Storyboard storyboard = new Storyboard
        {
            RepeatBehavior = new RepeatBehavior(1)
        };

        public static Ellipse AnimationEllipse = new Ellipse
        {
            Width = Globals.VertRadius,
            Height = Globals.VertRadius,
            Fill = Brushes.Blue
        };

        public static void RefreshStoryboard()
        {
            MainWindow.Instance.GraphCanvas.Children.Add(AnimationEllipse);

            var pathGeom = new PathGeometry();
            var vertPF = new PathFigure();
            var vertLS = new LineSegment();

            var startPoint = Point.Add(animatedEdge.From.Coordinates, Point.Subtract(animatedEdge.From.Coordinates, new Point(animatedEdge.From.Coordinates.X + Globals.VertRadius / 2, animatedEdge.From.Coordinates.Y + Globals.VertRadius / 2)));
            var finishPoint = Point.Add(animatedEdge.To.Coordinates, Point.Subtract(animatedEdge.To.Coordinates, new Point(animatedEdge.To.Coordinates.X + Globals.VertRadius / 2, animatedEdge.To.Coordinates.Y + Globals.VertRadius / 2)));

            vertPF.StartPoint = startPoint;
            vertLS.Point = finishPoint;

            vertPF.Segments.Add(vertLS);
            pathGeom.Figures.Add(vertPF);

            var moveCircleAnimation = new DoubleAnimationUsingPath
            {
                PathGeometry = pathGeom,
                Source = PathAnimationSource.X,
                Duration = TimeSpan.FromSeconds(Settings.animationTime)
            };

            Storyboard.SetTarget(moveCircleAnimation, AnimationEllipse);
            Storyboard.SetTargetProperty(moveCircleAnimation, new PropertyPath("(Canvas.Left)"));

            var moveCircleAnimation2 = new DoubleAnimationUsingPath
            {
                PathGeometry = pathGeom,
                Source = PathAnimationSource.Y,
                Duration = TimeSpan.FromSeconds(Settings.animationTime)
            };

            Storyboard.SetTarget(moveCircleAnimation2, AnimationEllipse);
            Storyboard.SetTargetProperty(moveCircleAnimation2, new PropertyPath("(Canvas.Top)"));

            storyboard.Children.Add(moveCircleAnimation);
            storyboard.Children.Add(moveCircleAnimation2);

            storyboard.Completed += Storyboard_Completed;
        }

        public static void Storyboard_Completed(object sender, EventArgs e)
        {
            
        }

        public static void NextAnimation(Edge edge, List<Edge> edgesUsed)
        {
            animatedEdge = edge;
            RefreshStoryboard();
            StartAnimation();
            EventHandler callback = null;

            callback = (o, args) => {
                MainWindow.Instance.InvalidateAlgo(edge);
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

        public static void StartAnimation()
        {   
            storyboard.Begin();
        }
    }
}
