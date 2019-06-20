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

namespace Graph_Editor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///


    public partial class MainWindow : Window
    {
        int globalIndex = 0;

        public static FigureHost graphHost = new FigureHost();

        public MainWindow()
        {
            InitializeComponent();
            graphCanvas.Children.Add(graphHost);
            WaitPanel.Visibility = Visibility.Hidden;
        }


        static public void Invalidate()
        {

            Pen pen = new Pen
            {
                Brush = Brushes.Black,
                Thickness = 3
            };

            graphHost.Children.Clear();
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();

            foreach (var edge in globals.edgesData)
            {

                if (edge.Directed)
                {
                    Point from = edge.From.Coordinates;
                    Point to = edge.To.Coordinates;
                    Point center = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

                    Point center_second = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

                    double d = Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));

                    double X = to.X - from.X;
                    double Y = to.Y - from.Y;

                    center_second.X = center.X - (X / d) * 10;
                    center_second.Y = center.Y - (Y / d) * 10;

                    double Xp = to.Y - from.Y;
                    double Yp = from.X - to.X;

                    Point left = new Point((center_second.X + (Xp / d) * 5), (center_second.Y + (Yp / d) * 5));
                    Point right = new Point((center_second.X - (Xp / d) * 5), (center_second.Y - (Yp / d) * 5));

                    drawingContext.DrawLine(pen, center, left);
                    drawingContext.DrawLine(pen, center, right);

                }
                drawingContext.DrawLine(pen, edge.From.Coordinates, edge.To.Coordinates);

            }

            foreach (Vertex vertex in globals.vertexData)
            {
                int radius = 20;
                drawingContext.DrawEllipse(Brushes.DarkGray, pen, vertex.Coordinates, radius, radius);

                FormattedText txt = new FormattedText(vertex.Index.ToString(),
                                 CultureInfo.GetCultureInfo("en-us"),
                                 FlowDirection.LeftToRight,
                                 new Typeface("Romanic"),
                                 20, Brushes.Black);

                drawingContext.DrawText(txt, new Point(vertex.Coordinates.X + (vertex.Index.ToString().Length * (-5)), vertex.Coordinates.Y - 10));
            }

            drawingContext.Close();
            graphHost.Children.Add(drawingVisual);
        }

        private void GraphCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Vertex vertexNow = new Vertex(globalIndex++, e.GetPosition(graphCanvas));
            globals.vertexData.Add(vertexNow);
            Invalidate();
        }

        private void Connect_Click_1(object sender, RoutedEventArgs e)
        {
            ConnectVertices connectVertices = new ConnectVertices();
            WaitPanel.Visibility = Visibility.Visible;
            WaitPanel.Background = Brushes.LightGray;
            connectVertices.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Algoritms algoritms = new Algoritms();
            WaitPanel.Visibility = Visibility.Visible;
            WaitPanel.Background = Brushes.LightGray;
            algoritms.Show();
        }
    }
}
