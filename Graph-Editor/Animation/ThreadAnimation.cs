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
using static Graph_Editor.Globals;
using Graph_Editor.Algoritms;

namespace Graph_Editor
{
    public class ThreadAnimation
    {
        public void SetStoryboard(Storyboard storyboard, Edge animatedEdge, Ellipse ellipseAnimation)
        {
            MainWindow.Instance.GraphCanvas.Children.Add(ellipseAnimation);

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
                Duration = TimeSpan.FromSeconds(OptionsWindow.settings.AnimationTime * animatedEdge.Weight)
            };

            Storyboard.SetTarget(moveCircleAnimation, ellipseAnimation);
            Storyboard.SetTargetProperty(moveCircleAnimation, new PropertyPath("(Canvas.Left)"));

            var moveCircleAnimation2 = new DoubleAnimationUsingPath
            {
                PathGeometry = pathGeom,
                Source = PathAnimationSource.Y,
                Duration = TimeSpan.FromSeconds(OptionsWindow.settings.AnimationTime * animatedEdge.Weight)
            };

            Storyboard.SetTarget(moveCircleAnimation2, ellipseAnimation);
            Storyboard.SetTargetProperty(moveCircleAnimation2, new PropertyPath("(Canvas.Top)"));

            storyboard.Children.Add(moveCircleAnimation);
            storyboard.Children.Add(moveCircleAnimation2);

            storyboard.Completed += Storyboard_Completed;
        }

        public void Storyboard_Completed(object sender, EventArgs e)
        {

        }

        public bool[] CheckVertex
        {
            get;
            set;
        }

        public void AnimationBypass(int startIndex)
        {
            List<Edge> ways = new List<Edge>();

            foreach(var edge in EdgesData)
            {
                if (edge.From.Index == startIndex)
                {
                    if (CheckVertex[edge.To.Index] != true)
                    {
                        ways.Add(edge);
                    }
                }
            }

            foreach(var edge in ways)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = Globals.VertRadius,
                    Height = Globals.VertRadius,
                    Fill = OptionsWindow.settings.AnimationEllipseColor
                };

                Storyboard newStoryboard = new Storyboard();

                SetStoryboard(newStoryboard, edge, ellipse);

                EventHandler callback = null;

                callback = (o, args) => {

                    CheckVertex[edge.To.Index] = true;

                    MainWindow.Instance.InvalidateAlgo(edge);

                    newStoryboard.Completed -= callback;

                    MainWindow.Instance.GraphCanvas.Children.Remove(ellipse);

                    AnimationBypass(edge.To.Index);
                };

                newStoryboard.Completed += callback;

                newStoryboard.RepeatBehavior = new RepeatBehavior(1);

                StartAnimation(newStoryboard);
            }
        }

        public void StartAnimation(Storyboard newStoryboard)
        {
            newStoryboard.Begin();
        }
    }
}
