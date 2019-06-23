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


namespace Graph_Editor
{
    static class AnimationEdge
    {
        public static Edge edge;

        //static MessageBox message = new MessageBox();

        private static Storyboard storyboard = new Storyboard
        {
            RepeatBehavior = new RepeatBehavior(1)
        };

        private static Ellipse ellipse = new Ellipse
        {
            Width = globals.vertRadius,
            Height = globals.vertRadius,
            Fill = Brushes.Blue
        };

        public static void Refresh_SrtoryBoard()
        {
            int time = 10;

            MainWindow.Instance.graphCanvas.Children.Add(ellipse);

            PathGeometry pathGeom = new PathGeometry();
            Path p = new Path();

            LineSegment vertLS = new LineSegment();
            PathFigure vertPF = new PathFigure();
            vertPF.StartPoint = edge.From.Coordinates;
            vertLS.Point = edge.To.Coordinates;
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

        private static void Storyboard_Completed(object sender, EventArgs e)
        {
            
        }

        //public static void start_thread()
        //{

        //}

        public static void Start_animation()
        {   
            storyboard.Begin();
            MessageBox.Show("");
            
        }

        //public static async void RusAni()
        //{
        //    await Task.Run(() => Start_animation());
        //}
    }
}
