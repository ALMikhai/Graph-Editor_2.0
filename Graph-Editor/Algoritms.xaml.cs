using Graph_Editor.AlgoritmClasses;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Graph_Editor
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Algoritms : Window
    {
        int chooseAlg;
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        public Algoritms()
        {
            InitializeComponent();
        }

        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            mainWindow.WaitPanel.Visibility = Visibility.Hidden;
        }
        private void main_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Alg_Click(object sender, RoutedEventArgs e)
        {
            chooseAlg = Convert.ToInt32((sender as Button).Tag.ToString());

            LockPanel.Background = Brushes.Gray;
            if (chooseAlg == 0 || chooseAlg == 1 || chooseAlg == 7)
            {
                BFS_DFS.Visibility = Visibility.Visible;
                FSstartVertex.Text = "0";
                BFS_DFS_label.Content = chooseAlg == 0 ? "BFS" : chooseAlg == 1 ? "DFS" : "Kruskall";
            }
            
            else if (chooseAlg == 2)
            {
                /*Dijkstra.Visibility = Visibility.Visible;
                DijkstrastartVertex.Text = "0";
                DijkstrafinalVertex.Text = "0";
                Dijkstra_Label.Content = "Dijkstra";*/
                MessageBox.Show("Sorry, algoritm is not ready now :(");
            }
            else
            {
                this.Close();
                switch (chooseAlg)
                {
                    case 3:
                        // Раскрашиваем граф ();
                        MessageBox.Show("Sorry, algoritm is not ready now :(");
                        break;
                    case 4:
                        // Гамильтонов цикл();
                        MessageBox.Show("Sorry, algoritm is not ready now :(");
                        break;
                    case 5:
                        // Эйлеров цикл();
                        MessageBox.Show("Sorry, algoritm is not ready now :(");
                        break;
                    case 6:
                        // Флойд-Уоршелл();
                        MessageBox.Show("Sorry, algoritm is not ready now :(");
                        break;
                    case 8:
                        // Максимальный поток();
                        MessageBox.Show("Sorry, algoritm is not ready now :(");
                        break;
                }
            }
        }

        private void Button_ReadyExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
           /* int vertex;
            bool isInt = Int32.TryParse(FSstartVertex.Text.ToString(), vertex)
            if ()*/
            if ((chooseAlg == 0 || chooseAlg == 1 || chooseAlg == 7) && Globals.IsBe(Convert.ToInt32(FSstartVertex.Text)) && FSstartVertex.Text != "")
            {
                BFS_DFS.Visibility = Visibility.Hidden;
                this.Close();
                
                if (chooseAlg == 0)
                {
                    Bfs.Start(Convert.ToInt32(FSstartVertex.Text));
                }
                else if (chooseAlg == 1)
                {
                    Dfs.Start(Convert.ToInt32(FSstartVertex.Text));
                }
                else if (chooseAlg == 7)
                {

                    Kruskal.Start(Convert.ToInt32(FSstartVertex.Text));
                }
            }
            /*else if (globals.IsBe(Convert.ToInt32(DijkstrastartVertex.Text)) && globals.IsBe(Convert.ToInt32(DijkstrafinalVertex.Text)) && chooseAlg == 2 && DijkstrastartVertex.Text != "" && DijkstrafinalVertex.Text != "")
            {
                if (Convert.ToInt32(DijkstrastartVertex.Text) != Convert.ToInt32(DijkstrafinalVertex.Text))
                {
                    this.Close();
                    Dijkstra.Visibility = Visibility.Hidden;
                    // Dijkstra();
                }
                else
                    MessageBox.Show("Enter different vertices");*/
            //}
            else
                MessageBox.Show("Invalid input data");
            
        }

        private void Button_ExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
            if (chooseAlg == 0 || chooseAlg == 1 || chooseAlg == 7)
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

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = Brushes.SkyBlue;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (String.Compare((sender as Button).Tag.ToString(), "Cancel") == 0)
                (sender as Button).Background = (Brush)new BrushConverter().ConvertFrom("#B9C2C2");
            else
                (sender as Button).Background = Brushes.CadetBlue;
        }
    }
}
