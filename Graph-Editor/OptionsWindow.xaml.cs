﻿using System;
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
using System.Windows.Shapes;

namespace Graph_Editor
{
    public partial class OptionsWindow : Window
    {
        private static FigureHost graphHost = new FigureHost();

        private double setNowSpeed;
        private int MaxSpeed = 200;

        private int Theme = Themes.ChooseTheme;

        private Brush vertexColor = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        private Brush edgeColor = Brushes.Black;
        private Brush animateColor;
        
        private string currentWindow;
        private string currentButtonWindow;

        private string setNowAnimationColor;
        private string setNowAnimationSpeed;

        private void ThemeSettings()
        {
            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();

            logo.Source = bitmap;

            MainWindow.Background        = Themes.OptionsMainWindowOptionsColor;
            ThemeButton.Background       = Themes.OptionsActiveToolBarButton;
            VertexEdgeButton.Background  = Themes.OptionsPassiveToolBarButton;
            AnimationButton.Background   = Themes.OptionsPassiveToolBarButton;

            AnimOkButton.Background      = Themes.OptionsWindowExitButtons;
            AnimCloseButton.Background   = Themes.OptionsWindowExitButtons;
            ThemeOkButton.Background     = Themes.OptionsWindowExitButtons;
            ThemeCloseButton.Background  = Themes.OptionsWindowExitButtons;
            VEOkButton.Background        = Themes.OptionsWindowExitButtons;
            VECloseButton.Background     = Themes.OptionsWindowExitButtons;

            Slow.Background              = Themes.OptionsPassiveAnimationSpeedButtons;
            Medium.Background            = Themes.OptionsPassiveAnimationSpeedButtons;
            Fast.Background              = Themes.OptionsPassiveAnimationSpeedButtons;
            VeryFast.Background          = Themes.OptionsPassiveAnimationSpeedButtons;
            AnimReset.Background         = Themes.OptionsPassiveAnimationSpeedButtons;

            VEReset.Background           = Themes.OptionsVEResetButton;
            VECheck.Background           = Themes.OptionsVECheckButton;
        }

        public OptionsWindow()
        {
            InitializeComponent();
            RestartWindow();

            DrawExample();
        }

        private void RestartWindow()
        {
            ThemeSettings();

            setNowEdge = Settings.BaseEdge;
            setNowVertex = Settings.BaseVertex;
            animateColor = Globals.AnimationEllipse.Fill;

            edgeColor = Themes.ColorEdge;
            vertexColor = Themes.ColorInsideVertex;

            setNowAnimationColor = Settings.baseAnimationColor;
            setNowAnimationSpeed = Settings.baseAnimationSpeed;
            setNowSpeed = Settings.animationTime;

            ((Button)this.FindName(Settings.BaseEdge)).Height = 30;
            ((Button)this.FindName(Settings.BaseVertex)).Height = 30;
            ((Button)this.FindName(Settings.BaseAnimationColor)).Height = 30;
            ((Button)this.FindName(Settings.BaseAnimationSpeed)).Background = Themes.OptionsActiveAnimationSpeedButtons;
            ((Button)this.FindName(Settings.currentTheme)).Background = Themes.OptionsVECheckButton;

            currentWindow = "ThemeGrid";
            currentButtonWindow = "ThemeButton";

            TextBox_Speed.Text = (-1 * (MaxSpeed + 175 * MaxSpeed)).ToString();

            TextBox_Speed.Text = (Settings.AnimationTime).ToString();

        }

        private void DrawExample()
        {
            exampleCanvas.Children.Clear();
            exampleCanvas.Children.Add(graphHost);

            graphHost.Children.Clear();
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();

            Point firstVertex = new Point(100, 100);
            Point secondVertex = new Point(200, 300);

            Pen pen = new Pen(edgeColor, Globals.ThicknessEdge);

            drawingContext.DrawLine(pen, firstVertex, secondVertex);

            drawingContext.DrawEllipse(vertexColor, Globals.BasePen, firstVertex, Globals.VertRadius, Globals.VertRadius);
            drawingContext.DrawEllipse(vertexColor, Globals.BasePen, secondVertex, Globals.VertRadius, Globals.VertRadius);

            drawingContext.Close();
            graphHost.Children.Add(drawingVisual);
        }

        private string setNowVertex;
        private string setNowEdge;

        private void ChangeVertexColorButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowVertex)).Height = 25;

            vertexColor = (sender as Button).Background;

            setNowVertex = (sender as Button).Name;
            (sender as Button).Height = 30;
        }

        private void ChangeEdgeColorButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowEdge)).Height = 25;

            edgeColor = (sender as Button).Background;

            setNowEdge = (sender as Button).Name;
            (sender as Button).Height = 30;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowVertex)).Height = 25;
            ((Button)this.FindName(setNowEdge)).Height = 25;

            ((Button)this.FindName(Settings.BaseVertex)).Height = 30;
            ((Button)this.FindName(Settings.BaseEdge)).Height = 30;

            setNowVertex = Settings.BaseVertex;
            setNowEdge = Settings.BaseEdge;

            vertexColor = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
            edgeColor = Brushes.Black;

            DrawExample();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            DrawExample();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            graphHost = new FigureHost();
            exampleCanvas.Children.Clear();
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            graphHost = new FigureHost();
            exampleCanvas.Children.Clear();

            Settings.baseVertex = setNowVertex;
            Settings.baseEdge = setNowEdge;

            Themes.ColorEdge = edgeColor;
            Themes.ColorInsideVertex = vertexColor;

            foreach(var vertex in Globals.VertexData)
            {
                vertex.Color = Themes.ColorInsideVertex;
            }

            foreach(var edge in Globals.EdgesData)
            {
                edge.Color = Themes.ColorEdge;
            }

            Graph_Editor.MainWindow.Instance.Invalidate();
            this.Close();
        }

        private void Rechoose(string name, object sender)
        {
            ((Grid)FindName(currentWindow)).Visibility = Visibility.Hidden;
            ((Grid)FindName(name)).Visibility = Visibility.Visible;

            ((Button)FindName(currentButtonWindow)).Background = Themes.OptionsPassiveToolBarButton;
            (sender as Button).Background = Themes.OptionsActiveToolBarButton;

            currentWindow = name;
            currentButtonWindow = (sender as Button).Name;
        }

        private void ChooseVertex_Edge_Menu(object sender, RoutedEventArgs e)
        {
            Rechoose("VertexEdgeGrid", sender);
        }

        private void ChooseThemeMenu(object sender, RoutedEventArgs e)
        {
            Rechoose("ThemeGrid", sender);
        }

        private void ChooseAnimationMenu(object sender, RoutedEventArgs e)
        {
            Rechoose("AnimationGrid", sender);
        }

        private void ChooseAnimationSpeed(object sender, double speed)
        {
            setNowSpeed = speed;
            ((Button)this.FindName(setNowAnimationSpeed)).Background = Themes.OptionsPassiveAnimationSpeedButtons;
            setNowAnimationSpeed = (sender as Button).Name;
            (sender as Button).Background = Themes.OptionsActiveAnimationSpeedButtons;
        }

        private void ChooseSlowAnimation(object sender, RoutedEventArgs e)
        {
            ChooseAnimationSpeed(sender, 3);
        }

        private void ChooseMediumAnimation(object sender, RoutedEventArgs e)
        {
            ChooseAnimationSpeed(sender, 1.5);
        }

        private void ChooseFastAnimation(object sender, RoutedEventArgs e)
        {
            ChooseAnimationSpeed(sender, 1);
        }

        private void ChooseVeryFastAnimation(object sender, RoutedEventArgs e)
        {
            ChooseAnimationSpeed(sender, 0.5);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double num = e.NewValue;
            ((Slider)sender).SelectionEnd = num;
            if (TextBox_Speed != null)
                TextBox_Speed.Text = Math.Round(num).ToString();
        }

        private void TextBox_Speed_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox_Speed.Text != "" && TextBox_Speed.Text != null)
            {
                double point = Convert.ToDouble(TextBox_Speed.Text);
                SpeedSlider.SelectionEnd = point;
                SpeedSlider.Value = point;
                setNowSpeed = (MaxSpeed - Convert.ToDouble(TextBox_Speed.Text)) / 175;
            }
        }

        private void animationOK_Click(object sender, RoutedEventArgs e)
        {
            Globals.AnimationEllipse.Fill = animateColor;
            Settings.BaseAnimationColor = setNowAnimationColor;

            Settings.AnimationTime = setNowSpeed;
            Settings.BaseAnimationSpeed = setNowAnimationSpeed;

            Settings.AnimationEllipseColor = animateColor;
            this.Close();
        }

        private void ChangeBallColorButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowAnimationColor)).Height = 25;

            animateColor = (sender as Button).Background;

            setNowAnimationColor = (sender as Button).Name;
            (sender as Button).Height = 30;
        }

        private void ResetAnimationColor_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowAnimationColor)).Height = 25;

            ((Button)this.FindName(Settings.BaseAnimationColor)).Height = 30;

            setNowAnimationColor = Settings.BaseAnimationColor;
            animateColor = Globals.AnimationEllipse.Fill;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            graphHost = new FigureHost();
            exampleCanvas.Children.Clear();
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.Settings.IsEnabled = true;
        }

        private void ThemeOK_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.ChooseTheme != Theme)
            {
                switch (Theme)
                {
                    case 1:
                        Themes.IceTheme();
                        Settings.currentTheme = "IceTheme";
                        break;
                    case 2:
                        Themes.VolcanoTheme();
                        Settings.currentTheme = "VulcanTheme";
                        break;
                }
            }
            Graph_Editor.MainWindow.Instance.ThemeSettings();
            this.ThemeSettings();
            this.Close();
        }

        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            if (Theme != 1)
            {
                VulcanTheme.Background = Brushes.Transparent;
                IceTheme.Background = Themes.OptionsVECheckButton;
                Theme = 1;
            }
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            if (Theme != 2)
            {
                IceTheme.Background = Brushes.Transparent;
                VulcanTheme.Background = Themes.OptionsVECheckButton;
                Theme = 2;
            }
        }
    }
}