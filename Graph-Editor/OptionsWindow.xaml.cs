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
        private double setNowSpeed;
        private int MaxSpeed = 200;

        private Brush vertexColor = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        private Brush edgeColor = Brushes.Black;
        private Brush animateColor;

        private string setNowVertex;
        private string setNowEdge;
        
        private string currentWindow;
        private string currentButtonWindow;

        private string setNowAnimationColor;
        private string setNowAnimationSpeed;

        private void ThemeSettings()
        {
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
        }

        private void RestartWindow()
        {
            ThemeSettings();

            setNowEdge = Settings.baseEdge;
            setNowVertex = Settings.baseVertex;
            animateColor = Globals.AnimationEllipse.Fill;

            setNowAnimationColor = Settings.baseAnimationColor;
            setNowAnimationSpeed = Settings.baseAnimationSpeed;
            setNowSpeed = Settings.animationTime;

            ((Button)this.FindName(Settings.baseEdge)).Height = 30;
            ((Button)this.FindName(Settings.baseVertex)).Height = 30;
            ((Button)this.FindName(Settings.baseAnimationColor)).Height = 30;
            ((Button)this.FindName(Settings.baseAnimationSpeed)).Background = Themes.OptionsActiveAnimationSpeedButtons;

            currentWindow = "ThemeGrid";
            currentButtonWindow = "ThemeButton";

        }

        private void ChangeVertexColorButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowVertex)).Height = 25;

            vertexColor = (sender as Button).Background;

            setNowVertex = (sender as Button).Name;
            (sender as Button).Height = 30;

            /*Globals.ColorInsideVertex = (sender as Button).Background;*/
        }
        private void ChangeEdgeColorButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowEdge)).Height = 25;

            edgeColor = (sender as Button).Background;

            setNowEdge = (sender as Button).Name;
            (sender as Button).Height = 30;

            /*Globals.ColorEdge = (sender as Button).Background;*/
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ((Button)this.FindName(setNowVertex)).Height = 25;
            ((Button)this.FindName(setNowEdge)).Height = 25;

            ((Button)this.FindName(Settings.baseVertex)).Height = 30;
            ((Button)this.FindName(Settings.baseEdge)).Height = 30;

            setNowVertex = Settings.baseVertex;
            setNowEdge = Settings.baseEdge;

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            // Меняем на картинку: "Images/Themes/{setNowVertex} + {setNowEdge}"
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Settings.baseVertex = setNowVertex;
            Settings.baseEdge = setNowEdge;
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
            if (TextBox_Speed.Text != "")
            {
                int point = Convert.ToInt32(TextBox_Speed.Text);
                SpeedSlider.SelectionEnd = point;
                SpeedSlider.Value = point;
                setNowSpeed = (MaxSpeed - Convert.ToDouble(TextBox_Speed.Text)) / 175;
            }
        }

        private void animationOK_Click(object sender, RoutedEventArgs e)
        {
            Globals.AnimationEllipse.Fill = animateColor;
            Settings.baseAnimationColor = setNowAnimationColor;

            Settings.animationTime = setNowSpeed;
            Settings.baseAnimationSpeed = setNowAnimationSpeed;

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

            ((Button)this.FindName(Settings.baseAnimationColor)).Height = 30;

            setNowAnimationColor = Settings.baseAnimationColor;
            animateColor = Globals.AnimationEllipse.Fill;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.Settings.IsEnabled = true;
        }

        private void ThemeOK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}