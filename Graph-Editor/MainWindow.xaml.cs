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
using System.ComponentModel;
using Graph_Editor.ShowData;

namespace Graph_Editor
{
    public partial class MainWindow : Window
    {
        public static FigureHost graphHost = new FigureHost();
        bool mouseDown = false;

        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            AddVertex.Background = Brushes.CadetBlue;
            graphCanvas.Children.Add(graphHost);
            Instance = this;
        }
        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            Exit_Dialog.Visibility = Visibility.Visible;
        }
        int chooseTool = 0;

        public void Invalidate()
        {
            graphCanvas.Children.Clear();
            graphCanvas.Children.Add(graphHost);
            
            graphHost.Children.Clear();
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();

            Pen pen = globals.pen;

            foreach (var edge in globals.edgesData)
            {
                Point from = edge.From.Coordinates;
                Point to = edge.To.Coordinates;

                Point center = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);
                Point center_second = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

                if (edge.Directed)
                {
                    double d = Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));

                    double X = to.X - from.X;
                    double Y = to.Y - from.Y;

                    center_second.X = center.X - (X / d) * 15;
                    center_second.Y = center.Y - (Y / d) * 15;

                    double Xp = to.Y - from.Y;
                    double Yp = from.X - to.X;

                    Point left = new Point((center_second.X + (Xp / d) * 6), (center_second.Y + (Yp / d) * 6));
                    Point right = new Point((center_second.X - (Xp / d) * 6), (center_second.Y - (Yp / d) * 6));

                    drawingContext.DrawLine(pen, center, left);
                    drawingContext.DrawLine(pen, center, right);
                }
                
                drawingContext.DrawLine(pen, edge.From.Coordinates, edge.To.Coordinates);

                //Draw weight.
                if (edge.Weight > 1)
                {
                    if (edge.Directed && globals.matrix[edge.To.Index, edge.From.Index] > 0)
                    {
                        drawingContext.DrawText(new FormattedText(edge.Weight.ToString(),
                                         CultureInfo.GetCultureInfo("en-us"),
                                         FlowDirection.LeftToRight,
                                         new Typeface("Romanic"),
                                         30, Brushes.Red), new Point((from.X + center.X) / 2, (from.Y + center.Y) / 2));
                    }
                    else
                    {
                        drawingContext.DrawText(new FormattedText(edge.Weight.ToString(),
                                         CultureInfo.GetCultureInfo("en-us"),
                                         FlowDirection.LeftToRight,
                                         new Typeface("Romanic"),
                                         30, Brushes.Red), center);
                    }
                }
            }


            pen = globals.pen;

            foreach (Vertex vertex in globals.vertexData)
            {
                
                drawingContext.DrawEllipse(globals.colorInsideVertex, globals.pen, vertex.Coordinates, globals.vertRadius, globals.vertRadius);

                FormattedText txt = new FormattedText(vertex.Index.ToString(),
                                 CultureInfo.GetCultureInfo("en-us"),
                                 FlowDirection.LeftToRight,
                                 new Typeface("Romanic"),
                                 20, (Brush)new BrushConverter().ConvertFrom("#305F5F"));

                drawingContext.DrawText(txt, new Point(vertex.Coordinates.X + (vertex.Index.ToString().Length * (-5)), vertex.Coordinates.Y - 10));
            }

            drawingContext.Close();
            graphHost.Children.Add(drawingVisual);
        }

        public void InvalidateAlgo(Edge e)
        {
            graphCanvas.Children.Remove(AnimationEdge.ellipse);
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();
            
            drawingContext.DrawLine(globals.algopen, e.From.Coordinates, e.To.Coordinates);

            if (e.Directed)
            {
                Point from = e.From.Coordinates;
                Point to = e.To.Coordinates;

                Point center = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);
                Point center_second = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

                double d = Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));

                double X = to.X - from.X;
                double Y = to.Y - from.Y;

                center_second.X = center.X - (X / d) * 15;
                center_second.Y = center.Y - (Y / d) * 15;

                double Xp = to.Y - from.Y;
                double Yp = from.X - to.X;

                Point left = new Point((center_second.X + (Xp / d) * 6), (center_second.Y + (Yp / d) * 6));
                Point right = new Point((center_second.X - (Xp / d) * 6), (center_second.Y - (Yp / d) * 6));

                drawingContext.DrawLine(globals.algopen, center, left);
                drawingContext.DrawLine(globals.algopen, center, right);
            }

            foreach (Vertex vertex in globals.vertexData)
            {

                drawingContext.DrawEllipse(globals.colorInsideVertex, globals.pen, vertex.Coordinates, globals.vertRadius, globals.vertRadius);

                FormattedText txt = new FormattedText(vertex.Index.ToString(),
                                 CultureInfo.GetCultureInfo("en-us"),
                                 FlowDirection.LeftToRight,
                                 new Typeface("Romanic"),
                                 20, (Brush)new BrushConverter().ConvertFrom("#305F5F"));

                drawingContext.DrawText(txt, new Point(vertex.Coordinates.X + (vertex.Index.ToString().Length * (-5)), vertex.Coordinates.Y - 10));
            }
            drawingContext.Close();
            graphHost.Children.Add(drawingVisual);
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            ConnectVertices connectVertices = new ConnectVertices();
            WaitPanel.Visibility = Visibility.Visible;
            WaitPanel.Opacity = 0.4;
            connectVertices.Show();
    }
        private void Algoritm_Button(object sender, RoutedEventArgs e)
        {
            Algoritms algoritms = new Algoritms();
            WaitPanel.Visibility = Visibility.Visible;
            algoritms.Show();
        }

        private void Change_Tool_Button(object sender, RoutedEventArgs e)
        {
            globals.toolNow = globals.toolList[Convert.ToInt32((sender as Button).Tag)];
            int button_num = Convert.ToInt32((sender as Button).Tag);

            globals.toolNow.Change_Tool();

            Brush brush = (Brush)new BrushConverter().ConvertFrom("#345160");

            if (button_num == 0)
            {
                MoveVertex.Background = brush;
                DelVertex.Background = brush;
                Connect.Background = brush;
                DelEdge.Background = brush;
                (sender as Button).Background = Brushes.CadetBlue;
            }
            else if (button_num == 1)
            {
                AddVertex.Background = brush;
                DelVertex.Background = brush;
                Connect.Background = brush;
                DelEdge.Background = brush;
                (sender as Button).Background = Brushes.CadetBlue;
            }
            else if (button_num == 2)
            {
                AddVertex.Background = brush;
                MoveVertex.Background = brush;
                Connect.Background = brush;
                DelEdge.Background = brush;
                (sender as Button).Background = Brushes.CadetBlue;
            }
            else if (button_num == 3)
            {
                AddVertex.Background = brush;
                MoveVertex.Background = brush;
                DelVertex.Background = brush;
                DelEdge.Background = brush;
                if (String.Compare((sender as Button).Background.ToString(), "#FF5F9EA0") != 0)
                {   
                    Connect.Background = Brushes.CadetBlue;
                }
                else
                    Connect_Click(sender, e);
            }
            else if (button_num == 4)
            {
                AddVertex.Background = brush;
                MoveVertex.Background = brush;
                DelVertex.Background = brush;
                Connect.Background = brush;
                (sender as Button).Background = Brushes.CadetBlue;
            }
            chooseTool = Convert.ToInt32((sender as Button).Tag);
        }

        private void GraphCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            globals.toolNow.Mouse_Down(e.GetPosition(graphCanvas));
            Invalidate();
        }

        private void GraphCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                globals.toolNow.Mouse_Move(e.GetPosition(graphCanvas));
                Invalidate();
            }
        }

        private void GraphCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                globals.toolNow.Mouse_Leave();
                Invalidate();
                mouseDown = false;
            }
        }

        private void GraphCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                globals.toolNow.Mouse_Up();
                Invalidate();
                mouseDown = false;
            }
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32((sender as Button).Tag) != chooseTool)
                (sender as Button).Background = (Brush)new BrushConverter().ConvertFrom("#4c7184");
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32((sender as Button).Tag) != chooseTool)
                (sender as Button).Background = (Brush)new BrushConverter().ConvertFrom("#345160");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save.Save_All();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Load.Loaded();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (globals.vertexData.Count > 0)
                Exit_Dialog.Visibility = Visibility.Visible;
            else
                this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < globals.globalIndex; i++)
                for (int j = 0; j < globals.globalIndex; j++)
                    globals.matrix[i,j] = 0;
            globals.vertexData.Clear();
            globals.edgesData.Clear();
            globals.globalIndex = 0;
            Invalidate();
        }

        private void Save_Exit_Click(object sender, RoutedEventArgs e)
        {
            Exit.Exit_and_Save_All(0);
        }

        private void Exit_Exit_Click(object sender, RoutedEventArgs e)
        {
            Exit.Exit_and_Save_All(1);
        }

        private void Cancel_Exit_Click(object sender, RoutedEventArgs e)
        {
            Exit.Exit_and_Save_All(2);
        }

        private void ShowMatrix(object sender, RoutedEventArgs e)
        {
            CurrentMatrix currentMatrix = new CurrentMatrix();
            WaitPanel.Visibility = Visibility.Visible;
            WaitPanel.Background = Brushes.Gray;
            currentMatrix.Show();
        }

        private void ShowList(object sender, RoutedEventArgs e)
        {
            CurrentList currentList = new CurrentList();
            WaitPanel.Visibility = Visibility.Visible;
            WaitPanel.Background = Brushes.Gray;
            currentList.Show();
        }

        private void ViewDocumentation(object sender, RoutedEventArgs e)
        {
            Documentation documentation = new Documentation();
            documentation.Show();
        }
    }
}
