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
using System.Windows.Shapes;

namespace Graph_Editor
{
    public partial class OptionsWindow : Window
    {
        private double setNowSpeed = 1;
        private int MaxSpeed = 200;

        private Brush vertexColor = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        private Brush edgeColor = Brushes.Black;

        private string setNowVertex;
        private string setNowEdge;
        private string currentWindow;
        private string currentButtonWindow;

        public OptionsWindow()
        {
            InitializeComponent();
            RestartWindow();
        }
        private void RestartWindow()
        {
            setNowEdge = Globals.BaseEdge;
            setNowVertex = Globals.BaseVertex;

            ((Button)this.FindName(Globals.BaseEdge)).Height = 30;
            ((Button)this.FindName(Globals.BaseVertex)).Height = 30;

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

            ((Button)this.FindName(Globals.BaseVertex)).Height = 30;
            ((Button)this.FindName(Globals.BaseEdge)).Height = 30;

            setNowVertex = Globals.BaseVertex;
            setNowEdge = Globals.BaseEdge;

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
            Globals.BaseVertex = setNowVertex;
            Globals.BaseEdge = setNowEdge;
            this.Close();
        }
        private void Rechoose(string name, object sender)
        {
            ((Grid)FindName(currentWindow)).Visibility = Visibility.Hidden;
            ((Grid)FindName(name)).Visibility = Visibility.Visible;

            ((Button)FindName(currentButtonWindow)).Background = Brushes.LightGray;
            (sender as Button).Background = Brushes.Gray;

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

        private void ChooseSlowAnimation(object sender, RoutedEventArgs e)
        {
            setNowSpeed = 3;
        }

        private void ChooseMediumAnimation(object sender, RoutedEventArgs e)
        {
            setNowSpeed = 1.5;
        }

        private void ChooseFastAnimation(object sender, RoutedEventArgs e)
        {
            setNowSpeed = 1;
        }

        private void ChooseVeryFastAnimation(object sender, RoutedEventArgs e)
        {
            setNowSpeed = 0.5;
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
            Globals.animationTime = setNowSpeed;
            this.Close();
        }
    }
}
