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

namespace Graph_Editor
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Algoritms : Window
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        public Algoritms()
        {
            InitializeComponent();
        }

        /*static Dictionary<int, Grid> gridAlg = new Dictionary<int, Grid>
        {
            {0, BFS},
        };*/

        public void Algoritm_Ready()
        {
            mainWindow.WaitPanel.Background = null;
            mainWindow.WaitPanel.Opacity = 0;

            mainWindow.Activate();
        }
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            mainWindow.WaitPanel.Background = null;
            mainWindow.WaitPanel.Opacity = 0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BFS_Cancle_Click(object sender, RoutedEventArgs e)
        {
            BFS.Visibility = Visibility.Hidden;
            LockPanel.Background = null;
        }

        private void Button_ReadyExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
            if (FSstartVertex.Text != "")
            {
                if (Globals.IsBe(Convert.ToInt32(FSstartVertex.Text)))
                {
                    this.Close();
                    BFS.Visibility = Visibility.Hidden;
                    switch (Convert.ToInt32((sender as Button).Tag.ToString()))
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                break;
                            }
                        case 2:
                            {
                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                        case 4:
                            {
                                break;
                            }
                        case 5:
                            {
                                break;
                            }
                        case 6:
                            {
                                break;
                            }
                        case 7:
                            {
                                break;
                            }
                        case 8:
                            {
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("This vertex doesn't exist");
                }
            }
            else
            {
                MessageBox.Show("Input a vertex");
            }
        }

        private void Button_Alg_Click(object sender, RoutedEventArgs e)
        {
            LockPanel.Background = Brushes.Gray;
            switch (Convert.ToInt32((sender as Button).Tag.ToString()))
            {
                case 0:
                    {
                        BFS.Visibility = Visibility.Visible;
                        FSstartVertex.Text = "0";
                        break;
                    }
                case 1:
                    {
                        BFS.Visibility = Visibility.Visible;
                        FSstartVertex.Text = "0";
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        break;
                    }
                case 8:
                    {
                        break;
                    }
            }

        }
    }
}
