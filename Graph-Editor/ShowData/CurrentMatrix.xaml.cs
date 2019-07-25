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
using System.ComponentModel;

namespace Graph_Editor.ShowData
{
    public partial class CurrentMatrix : Window
    {
        private void ThemeSetting()
        {
            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();

            logo.Source = bitmap;

            fullWindow.Background = Themes.FloydMainWindow;
            mainBlock.Background = Themes.FloydTextBlocks;
            topBlock.Background = Themes.FloydTextBlocks;
            sideBlock.Background = Themes.FloydTextBlocks;

        }

        public CurrentMatrix()
        {
            InitializeComponent();

            ThemeSetting();

            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                topBlock.Text += i.ToString() + " ";
            }

            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                sideBlock.Text += i.ToString() + "\n";
            }

            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                for (int j = 0; j < Globals.GlobalIndex; j++)
                {
                    int k = j.ToString().Length;
                    if (k > 1)
                    {
                        mainBlock.Text += Globals.Matrix[i, j].ToString();
                        while (k > 0)
                        {
                            mainBlock.Text += " ";
                            k--;
                        }
                        mainBlock.Text += " ";
                    }
                    else
                    {
                        mainBlock.Text += Globals.Matrix[i, j].ToString();
                        mainBlock.Text += " ";
                    }
                    
                    
                }
                mainBlock.Text += "\n";
            }
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

            if (mainWindow != null && mainWindow.WaitPanel != null)
            {
                mainWindow.WaitPanel.Background = null;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
