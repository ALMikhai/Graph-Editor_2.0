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
    public partial class Documentation : Window
    {

        private void ThemeSettings()
        {
            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();

            logo.Source = bitmap;

            CreatorsButton.Background   = Themes.DocCreatorsButton;
            Creators.Opacity            = Themes.DocCreatorsWindowOpacity;
            Creators.Background         = Themes.DocCreatorsWindow;
            WindowMain.Background       = Themes.DocMainWindow;

            forWhatAndWho.Background    = Themes.DocMainWindow;
            Instruct.Background         = Themes.DocMainWindow;
            useOfIt.Background          = Themes.DocMainWindow;

            end.Background              = Themes.DocExitButton;
        }

        public Documentation()
        {
            InitializeComponent();
            ThemeSettings();
            forWhatAndWho.Text += "1) This program was created to demonstrate the work with graphs.\n\n" +
                "2) This application can be used by both students and teachers.";
            useOfIt.Text += "1) For students, this is the highest-quality presentation of information about working with graphs.\n\n" +
                "2) For teachers it is a chance, in the most understandable way for everyone, to thoroughly explain what a graph is, and most of its algorithms.";
            Instruct.Text += "We will start ICON counting from top left to bottom. \n\n" +
                "1) Empty circle. With the tool selected, you can add vertices to a portion of the light blue color window, called the canvas.\n\n" +
                "2) The hand. With the selected tool, you can move the vertices without fear of accidentally adding a new vertex.\n\n" +
                "3) Circle with a cross inside. With the tool selected, you can delete the vertex and all edges connected to it.\n\n" +
                "4) Straight with a cross. With the tool selected, you can delete the edge by selecting 2 vertices.\n\n" +
                "5) Straight without a cross. With the tool selected, you can add the edge between 2 selected vertices";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Creators.Visibility = Visibility.Visible;
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            Creators.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Creators.Visibility = Visibility.Hidden;
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.viewDoc.IsEnabled = true;
        }

        private void End_MouseLeave(object sender, MouseEventArgs e)
        {
            end.Background = Themes.DocExitButton;
        }

        private void End_MouseMove(object sender, MouseEventArgs e)
        {
            end.Background = Themes.DocExitButtonHover;
        }
    }
}
