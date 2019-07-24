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
    // CodeStyle.
    // 1) Переменный - локальные(Camel casing), глобальные(Pascal casing).
    // 2) Приватные, защищённые поля(Camel casing) публичные поля, свойства(Pascal casing).
    // 3) Аргументы функций(Camel casing).
    // 4) В объявлении foreach использовать var, в объявлении переменных где будет понятен тип переменной использовать var.
    // 5) Названия функций(Camel casing).
    // 6) В назывниях функциий, переменных и даже в xaml'е не должно присутствовать знака подчеркивания '_' (только в тех случаях, когда это делает студия).
    // 7) Названия переменных и функций должны быть понятны всем, а не только тому кто это писал.
    // 8) Не использовать сокращения в названиях переменных и функций.
    
    // TODO База данных, через серилизацию.
    // TODO Сделать генерацию цветов для быстрой смены.

    public partial class MainWindow : Window
    {
        private Brush baseButtonColor;
        private static FigureHost graphHost = new FigureHost();
        public static MainWindow Instance { get; private set; }

        public void ThemeSettings()
        {
            baseButtonColor = Themes.MainToolsButtons;

            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();

            logo.Source = bitmap;

            FullWindow.Background = Themes.MainMainWindow;

            TeamName.Background = Themes.MainTeamName;

            Algorimts_Window.Background = Themes.MainToolsButtons;
            AddVertex.Background = Themes.MainToolsButtons;
            MoveVertex.Background = Themes.MainToolsButtons;
            DelVertex.Background = Themes.MainToolsButtons;
            DelEdge.Background = Themes.MainToolsButtons;
            Connect.Background = Themes.MainToolsButtons;

            GraphCanvas.Background = Themes.MainCanvas;

            MainMenu.Background = Themes.MainMenu;
            save.Background = Themes.MainMenuItems;
            open.Background = Themes.MainMenuItems;
            exit.Background = Themes.MainMenuItems;
            matrix.Background = Themes.MainMenuItems;
            list.Background = Themes.MainMenuItems;

            save.BorderBrush = Themes.MainMenuItemsBorder;
            open.BorderBrush = Themes.MainMenuItemsBorder;
            exit.BorderBrush = Themes.MainMenuItemsBorder;
            matrix.BorderBrush = Themes.MainMenuItemsBorder;
            list.BorderBrush = Themes.MainMenuItemsBorder;

            Exit_Dialog.Background = Themes.MainExitDialog;
        }

        public MainWindow()
        {
            InitializeComponent();
            Themes.VolcanoTheme();

            ThemeSettings();

            AddVertex.Background = Themes.MainChooseToolButton;
            list.Background = Brushes.Gray;

            GraphCanvas.Children.Add(graphHost);
            Instance = this;

            ButtonGeneration.ColorButtonGeneration();
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
                                                CultureInfo.GetCultureInfo("en -us"),
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

            foreach (var vertex in Globals.VertexData)
            {
                drawingContext.DrawEllipse(vertex.Color, Globals.BasePen, vertex.Coordinates, Globals.VertRadius, Globals.VertRadius);

                FormattedText txt = new FormattedText(vertex.Index.ToString(),
                                    CultureInfo.GetCultureInfo("en-us"),
                                    FlowDirection.LeftToRight,
                                    new Typeface("Romanic"),
                                    20, Themes.ColorOfTheTextOfVertex);

                drawingContext.DrawText(txt, new Point(vertex.Coordinates.X + (vertex.Index.ToString().Length * (-5)), vertex.Coordinates.Y - 10));
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
            connectVertices.Show();
        }

        private void AlgoritmButton_Click(object sender, RoutedEventArgs e)
        {
            AlgoritmsWindow algoritms = new AlgoritmsWindow();
            WaitPanel.Visibility = Visibility.Visible;
            Algorimts_Window.IsEnabled = false;
            algoritms.Show();
        }

        private void Change_Tool_Button(object sender, RoutedEventArgs e)
        {
            Globals.ToolNow.Change_Tool();

            Invalidate();

            Globals.ToolNow = Globals.ToolList[Convert.ToInt32((sender as Button).Tag)];

            int SelectedToolIndex = Convert.ToInt32((sender as Button).Tag);

            if (SelectedToolIndex == 3)
            {
                if (string.Compare((sender as Button).Background.ToString(), "#FF5F9EA0") == 0 || string.Compare((sender as Button).Background.ToString(), "#FF3F2030") == 0) 
                {
                    Connect_Click(sender, e);
                    Connect.IsEnabled = false;
                }
            }

            AddVertex.Background = baseButtonColor;
            MoveVertex.Background = baseButtonColor;
            DelVertex.Background = baseButtonColor;
            Connect.Background = baseButtonColor;
            DelEdge.Background = baseButtonColor;
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
            if (string.Compare((sender as Button).Background.ToString(), "#FF5F9EA0") != 0 && string.Compare((sender as Button).Background.ToString(), "#FF3F2030") != 0)
            {
                (sender as Button).Background = Themes.MainToolsButtonsHover;
            }
        }

        private void ToolButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.Compare((sender as Button).Background.ToString(), "#FF5F9EA0") != 0 && string.Compare((sender as Button).Background.ToString(), "#FF3F2030") != 0)
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
            Exit_Dialog.Visibility = Visibility.Visible;
        }

        private void ShowMatrix(object sender, RoutedEventArgs e)
        {
            CurrentMatrix currentMatrix = new CurrentMatrix();
            WaitPanel.Visibility = Visibility.Visible;
            currentMatrix.Show();
        }

        private void ShowList(object sender, RoutedEventArgs e)
        {
            CurrentList currentList = new CurrentList();
            WaitPanel.Visibility = Visibility.Visible;
            currentList.Show();
        }

        private void ViewDocumentation(object sender, RoutedEventArgs e)
        {
            viewDoc.IsEnabled = false;
            Documentation documentation = new Documentation();
            documentation.Show();
        }

        private void GoToOptions(object sender, RoutedEventArgs e)
        {
            Settings.IsEnabled = false;
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
                Themes.ColorInsideVertex = (sender as Button).Background;
            }
        }
    }
}
