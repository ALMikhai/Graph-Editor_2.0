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
        int chooseAlg;
        public Algoritms()
        {
            InitializeComponent();
        }

        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.WaitPanel.Background = null;
            mainWindow.WaitPanel.Opacity = 0;
        }

        private void main_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Alg_Click(object sender, RoutedEventArgs e)
        {
            chooseAlg = Convert.ToInt32((sender as Button).Tag.ToString());

            LockPanel.Background = Brushes.Gray;
            if (chooseAlg == 0 || chooseAlg == 1)
            {
                BFS_DFS.Visibility = Visibility.Visible;
                FSstartVertex.Text = "0";
            }
            else if (chooseAlg == 2)
            {
                Dijkstra.Visibility = Visibility.Visible;
                DijkstrastartVertex.Text = "0";
                DijkstrafinalVertex.Text = "0";
            }
            else
            {
                this.Close();
                switch (chooseAlg)
                {
                    case 3:
                        // Раскрашиваем граф ();
                        break;
                    case 4:
                        // Гамильтонов цикл();
                        break;
                    case 5:
                        // Эйлеров цикл();
                        break;
                    case 6:
                        // Флойд-Уоршелл();
                        break;
                    case 7:
                        // Радиус и диаметр графа();
                        break;
                    case 8:
                        // Максимальный поток();
                        break;
                }
            }
        }

        private void Button_ReadyExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
            if ((chooseAlg == 0 || chooseAlg == 1) && globals.IsBe(Convert.ToInt32(FSstartVertex.Text)) && FSstartVertex.Text != "")
            {
                BFS_DFS.Visibility = Visibility.Hidden;
                this.Close();
                if (chooseAlg == 0)
                {
                    //bfs();
                } else
                {
                    //dfs();
                }
            }
            else if (globals.IsBe(Convert.ToInt32(DijkstrastartVertex.Text)) && globals.IsBe(Convert.ToInt32(DijkstrafinalVertex.Text)) && chooseAlg == 2
                     && DijkstrastartVertex.Text != "" && DijkstrafinalVertex.Text != "")
            {
                if (Convert.ToInt32(DijkstrastartVertex.Text) != Convert.ToInt32(DijkstrafinalVertex.Text))
                {
                    this.Close();
                    Dijkstra.Visibility = Visibility.Hidden;
                    // Dijkstra();
                }
                else
                    MessageBox.Show("Enter different vertices");
            }
            else
                MessageBox.Show("Invalid input data");
        }

        private void Button_ExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
            if (chooseAlg == 0 || chooseAlg == 1)
            {
                BFS_DFS.Visibility = Visibility.Hidden;
                LockPanel.Background = null;
            }
            else if (chooseAlg == 2)
            {
                Dijkstra.Visibility = Visibility.Hidden;
                LockPanel.Background = null;
            }
        }
    }
}
