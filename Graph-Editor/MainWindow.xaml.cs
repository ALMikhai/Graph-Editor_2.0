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
using System.ComponentModel;
using Graph_Editor.ShowData;
using Graph_Editor.UndoRedo;

namespace Graph_Editor
{

    /// <summary>
    ///  TODO Доделать историю для resize.
    ///  TODO Отслеживать историю (если 100 записей, 50 первых сбросить).
    ///  TODO Раскидать всё по папкам.
    /// </summary>

    public partial class MainWindow : Window
    {
        private Brush baseButtonColor;
        private string setNowTool = "AddVertex";

        public static FigureHost graphHost = new FigureHost();
        public static MainWindow Instance { get; private set; }

        public void ThemeSettings()
        {

            if(OptionsWindow.settings.ChooseTheme == 1)
            {
                Themes.IceTheme();
            }
            else
            {
                Themes.VolcanoTheme();
            }

            baseButtonColor = Themes.MainToolsButtons;

            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();

            logo.Source = bitmap;

            FullWindow.Background       = Themes.MainMainWindow;

            TeamName.Background         = Themes.MainTeamName;

            Algorimts_Window.Background = Themes.MainToolsButtons;
            AddVertex.Background        = Themes.MainToolsButtons;
            MoveVertex.Background       = Themes.MainToolsButtons;
            DelVertex.Background        = Themes.MainToolsButtons;
            DelEdge.Background          = Themes.MainToolsButtons;
            Connect.Background          = Themes.MainToolsButtons;
            MoveAllVertex.Background    = Themes.MainToolsButtons;
            PropertyVertex.Background   = Themes.MainToolsButtons;
            PropertyEdge.Background     = Themes.MainToolsButtons;
            CenterTheGraph.Background   = Themes.MainToolsButtons;

            GraphCanvas.Background      = Themes.MainCanvas;

            MainMenu.Background         = Themes.MainMenu;
            save.Background             = Themes.MainMenuItems;
            open.Background             = Themes.MainMenuItems;
            export.Background           = Themes.MainMenuItems;
            exit.Background             = Themes.MainMenuItems;
            saveTxtGraph.Background     = Themes.MainMenuItems;
            matrix.Background           = Themes.MainMenuItems;

            save.BorderBrush            = Themes.MainMenuItemsBorder;
            open.BorderBrush            = Themes.MainMenuItemsBorder;
            export.BorderBrush          = Themes.MainMenuItemsBorder;
            exit.BorderBrush            = Themes.MainMenuItemsBorder;
            saveTxtGraph.BorderBrush    = Themes.MainMenuItemsBorder;
            matrix.BorderBrush          = Themes.MainMenuItemsBorder;

            Exit_Dialog.Background      = Themes.MainExitDialog;
        }

        public MainWindow()
        {
            SaveLoad.LoadOptions.Load();

            InitializeComponent();

            ThemeSettings();

            ((Button)this.FindName(setNowTool)).Background = Themes.MainChooseToolButton;

            GraphCanvas.Children.Add(graphHost);

            Instance = this;

            ButtonGeneration.ColorButtonGeneration();

            CenterTheGraph.Click += CenterGraph.MoveGraph;
            saveTxtGraph.Click += SaveLoad.SaveGraphTextFormat.Save;
        }

        public void Invalidate()
        {
            GraphCanvas.Children.Clear();
            GraphCanvas.Children.Add(graphHost);
            
            graphHost.Children.Clear();
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();

            foreach (var edge in Globals.EdgesData)
            {
                Point from = edge.From.Coordinates;
                Point to = edge.To.Coordinates;

                var center = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);
                var centerSecond = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

                Pen pen = new Pen(edge.Color, edge.Thickness);

                if (edge.Directed)
                {
                    double d = Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));

                    double X = to.X - from.X;
                    double Y = to.Y - from.Y;

                    centerSecond.X = center.X - (X / d) * 15;
                    centerSecond.Y = center.Y - (Y / d) * 15;

                    double Xp = to.Y - from.Y;
                    double Yp = from.X - to.X;

                    var left = new Point((centerSecond.X + (Xp / d) * 6), (centerSecond.Y + (Yp / d) * 6));
                    var right = new Point((centerSecond.X - (Xp / d) * 6), (centerSecond.Y - (Yp / d) * 6));
                    
                    drawingContext.DrawLine(pen, center, left);
                    drawingContext.DrawLine(pen, center, right);
                }
                
                drawingContext.DrawLine(pen, edge.From.Coordinates, edge.To.Coordinates);
                
                if (edge.Weight > 1)
                {
                    if (edge.Directed && (Globals.Matrix[edge.To.Index, edge.From.Index] > 0))
                    {
                        drawingContext.DrawText(new FormattedText(edge.Weight.ToString(),
                                                CultureInfo.GetCultureInfo("en-us"),
                                                ((from.X < to.X && from.Y < to.Y) || (from.X > to.X && from.Y > to.Y)) ? FlowDirection.RightToLeft : FlowDirection.LeftToRight,
                                                new Typeface("Romanic"),
                                                30, Brushes.Red), new Point((from.X + center.X) / 2, (from.Y + center.Y) / 2));
                    }
                    else
                    {
                        drawingContext.DrawText(new FormattedText(edge.Weight.ToString(),
                                                CultureInfo.GetCultureInfo("en-us"),
                                                ((from.X < to.X && from.Y < to.Y) || (from.X > to.X && from.Y > to.Y)) ? FlowDirection.RightToLeft : FlowDirection.LeftToRight,
                                                new Typeface("Romanic"),
                                                30, Brushes.Red), 
                                                center);
                    }
                }
            }

            foreach (var vertex in Globals.VertexData)
            {
                drawingContext.DrawEllipse(vertex.Color, Globals.BasePen, vertex.Coordinates, Globals.VertRadius, Globals.VertRadius);

                FormattedText txt = new FormattedText((vertex.Text == "") ? vertex.Index.ToString() : vertex.Text,
                                    CultureInfo.GetCultureInfo("en-us"),
                                    FlowDirection.LeftToRight,
                                    new Typeface("Romanic"),
                                    20, Themes.ColorOfTheTextOfVertex);

                drawingContext.DrawText(txt, new Point(vertex.Coordinates.X + ((vertex.Text == "") ? vertex.Index.ToString().Length * (-5) : vertex.Text.Length * (-5)), vertex.Coordinates.Y - 10));
            }
            
            drawingContext.Close();
            graphHost.Children.Add(drawingVisual);
        }

        public void InvalidateAlgo(Edge edge)
        {
            GraphCanvas.Children.Remove(Globals.AnimationEllipse);
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();
            
            drawingContext.DrawLine(Globals.AlgoPen, edge.From.Coordinates, edge.To.Coordinates);

            if (edge.Directed)
            {
                Point from = edge.From.Coordinates;
                Point to = edge.To.Coordinates;

                var center = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);
                var centerSecond = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

                double d = Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));

                double X = to.X - from.X;
                double Y = to.Y - from.Y;

                centerSecond.X = center.X - (X / d) * 15;
                centerSecond.Y = center.Y - (Y / d) * 15;

                double Xp = to.Y - from.Y;
                double Yp = from.X - to.X;

                var left = new Point((centerSecond.X + (Xp / d) * 6), (centerSecond.Y + (Yp / d) * 6));
                var right = new Point((centerSecond.X - (Xp / d) * 6), (centerSecond.Y - (Yp / d) * 6));

                drawingContext.DrawLine(Globals.AlgoPen, center, left);
                drawingContext.DrawLine(Globals.AlgoPen, center, right);
            }

            foreach (var vertex in Globals.VertexData)
            {
                drawingContext.DrawEllipse(vertex.Color, Globals.BasePen, vertex.Coordinates, Globals.VertRadius, Globals.VertRadius);

                FormattedText txt = new FormattedText((vertex.Text == "") ? vertex.Index.ToString() : vertex.Text,
                                    CultureInfo.GetCultureInfo("en-us"),
                                    FlowDirection.LeftToRight,
                                    new Typeface("Romanic"),
                                    20, (Brush)new BrushConverter().ConvertFrom("#305F5F"));

                drawingContext.DrawText(txt, new Point(vertex.Coordinates.X + ((vertex.Text == "") ? vertex.Index.ToString().Length * (-5) : vertex.Text.Length * (-5)), vertex.Coordinates.Y - 10));
            }

            drawingContext.Close();
            graphHost.Children.Add(drawingVisual);
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            ConnectVertices connectVertices = new ConnectVertices();
            WaitPanel.Visibility = Visibility.Visible;
            connectVertices.ShowDialog();
        }

        private void AlgoritmButton_Click(object sender, RoutedEventArgs e)
        {
            AlgoritmsWindow algoritms = new AlgoritmsWindow();
            WaitPanel.Visibility = Visibility.Visible;
            Algorimts_Window.IsEnabled = false;
            algoritms.ShowDialog();
        }

        private void Change_Tool_Button(object sender, RoutedEventArgs e)
        {
            Globals.ToolNow.Change_Tool();

            ((Button)this.FindName(setNowTool)).Background = baseButtonColor;

            setNowTool = (sender as Button).Name;
            Globals.ChosenTool = setNowTool;

            Invalidate();

            Globals.ToolNow = Globals.ToolList[Convert.ToInt32((sender as Button).Tag)];

            int SelectedToolIndex = Convert.ToInt32((sender as Button).Tag);

            if (SelectedToolIndex == 3)
            {
                if (string.Compare((sender as Button).Background.ToString(), Themes.MainToolsButtons.ToString()) == 0)
                {
                    Connect.IsEnabled = false;
                    Connect_Click(sender, e);
                }
            }

            (sender as Button).Background = Themes.MainChooseToolButton;
        }

        private void GraphCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Globals.ToolNow.Mouse_Down(e.GetPosition(GraphCanvas));
            Invalidate();
        }

        private void GraphCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Globals.ToolNow.Mouse_Move(e.GetPosition(GraphCanvas));
                Invalidate();
            }
        }

        private void GraphCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            Globals.ToolNow.Mouse_Up();
            Invalidate();
        }

        private void GraphCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Globals.ToolNow.Mouse_Up();
                Invalidate();
            }
        }

        private void ToolButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (string.Compare((sender as Button).Background.ToString(), Themes.MainChooseToolButton.ToString()) != 0)
            {
                (sender as Button).Background = Themes.MainToolsButtonsHover;
            }
        }

        private void ToolButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.Compare((sender as Button).Background.ToString(), Themes.MainChooseToolButton.ToString()) != 0)
            {
                (sender as Button).Background = Themes.MainToolsButtons;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save.SaveAll();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Load.Loaded();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.VertexData.Count > 0)
            {
                Exit_Dialog.Visibility = Visibility.Visible;
            }
            else
            {
                this.Close();
            }
        }

        public void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            List<Vertex> vertices = new List<Vertex>();
            foreach(var vertex in Globals.VertexData)
            {
                vertices.Add(new Vertex(vertex));
            }

            List<Edge> edges = new List<Edge>();
            foreach(var edge in Globals.EdgesData)
            {
                edges.Add(new Edge(edge));
            }

            History.Add(vertices, edges);

            Globals.VertexData.Clear();
            Globals.EdgesData.Clear();
            Globals.GlobalIndex = 0;
            Globals.RestoreMatrix();
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

        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            SaveLoad.SaveOptions.Save();
            Exit_Dialog.Visibility = Visibility.Visible;
        }

        private void ShowMatrix(object sender, RoutedEventArgs e)
        {
            CurrentMatrix currentMatrix = new CurrentMatrix();
            WaitPanel.Visibility = Visibility.Visible;
            currentMatrix.ShowDialog();
        }

        private void ShowList(object sender, RoutedEventArgs e)
        {
            CurrentList currentList = new CurrentList();
            WaitPanel.Visibility = Visibility.Visible;
            currentList.ShowDialog();
        }

        private void ViewDocumentation(object sender, RoutedEventArgs e)
        {
            Documentation documentation = new Documentation();
            documentation.ShowDialog();
        }

        private void GoToOptions(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Z & Keyboard.Modifiers == ModifierKeys.Control)
            {
                History.UndoRedo(0);
                Invalidate();
            }

            if (e.Key == Key.Y & Keyboard.Modifiers == ModifierKeys.Control)
            {
                History.UndoRedo(1);
                Invalidate();
            }
        }

        public void ChangeColor(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Tag.ToString() == "0")
            {
                OptionsWindow.settings.ColorInsideVertex = (sender as Button).Background;
            }
        }

        private void GraphCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta > 0)
            {
                ResizeGraph.IncreaseCanvas(GraphCanvas.ActualHeight, GraphCanvas.ActualWidth);
                Invalidate();
            }
            else
            {
                ResizeGraph.DecreaseCanvas(GraphCanvas.ActualHeight, GraphCanvas.ActualWidth);
                Invalidate();
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.Export.ExportPng(sender, e);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SetGraph setGraph = new SetGraph();
            setGraph.ShowDialog();
        }
    }
}
