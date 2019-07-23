using Graph_Editor.Algoritms;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Graph_Editor.Globals;

namespace Graph_Editor
{
    public partial class AlgoritmsWindow : Window
    {
        // Баг - при нажатии на не готовый алгоритм, появляется messagebox после которого всё блочится.

        int chooseAlg;

        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        
        private void ThemeSettings()
        {
            MainWindow.Background           = Themes.AlgoMainWindowColor;

            BFSButton.Background            = Themes.AlgoIsAlgoReady;
            DFSButton.Background            = Themes.AlgoIsAlgoReady;
            DijkstraButton.Background       = Themes.AlgoIsAlgoReady;
            ColorButton.Background          = Themes.AlgoIsAlgoReady;
            HamiltonianButton.Background    = Themes.AlgoIsAlgoReady;
            EulerButton.Background          = Themes.AlgoIsAlgoReady;
            FloydButton.Background          = Themes.AlgoIsAlgoReady;
            KruskalButton.Background        = Themes.AlgoIsAlgoReady;
            MaximumButton.Background        = Themes.AlgoIsAlgoReady;

            CancelButton.Background         = Themes.AlgoCancelButton;
        }

        public AlgoritmsWindow()
        {
            InitializeComponent();
            ThemeSettings();
        }

        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            mainWindow.WaitPanel.Visibility = Visibility.Hidden;
            mainWindow.Algorimts_Window.IsEnabled = true;
        }

        private void main_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Alg_Click(object sender, RoutedEventArgs e)
        {
            chooseAlg = Convert.ToInt32((sender as Button).Tag.ToString());

            LockPanel.Visibility = Visibility.Visible;

            if (chooseAlg == 0 || chooseAlg == 1 || chooseAlg == 7)
            {
                BFS_DFS.Visibility = Visibility.Visible;
                FSstartVertex.Text = "0";
                BFS_DFS_label.Content = chooseAlg == 0 ? "BFS" : chooseAlg == 1 ? "DFS" : "Kruskall";
            }

            else if (chooseAlg == 2)
            {
                Dijkstra.Visibility = Visibility.Visible;
                DijkstrastartVertex.Text = "0";
                DijkstrafinalVertex.Text = "0";
                Dijkstra_Label.Content = "Dijkstra";
            }

            else
            {
                // Вот здесь просто ебани вон ту хуйню, ибо я не шарю как там всё происходит
                // Вот тебе теги и их алгоритмы:
                // 3 - Раскараска графа
                // 4 - Гамильтонов цикл
                // 5 - Эйлеров цикл
                // 6 - Флойд-Уоршелл
                // 8 - Максимальный поток
                // Здесь нет никаких стартовых вершин, сами номера алгоритмов хранятся в переменной chooseAlg
                // Я так понимаю, ты хотел сделать так: 
                // AlgoList[chooseAlg].Start();

                LockPanel.Visibility = Visibility.Hidden;
            }
        }

        private void DijkstraReadyExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
            if (DijkstrastartVertex.Text != "" && Globals.IsBe(Convert.ToInt32(DijkstrastartVertex.Text)) && DijkstrastartVertex.Text != DijkstrafinalVertex.Text && 
                DijkstrafinalVertex.Text != "" && Globals.IsBe(Convert.ToInt32(DijkstrafinalVertex.Text)))
            {
                Dijkstra.Visibility = Visibility.Hidden;
                this.Close();

                AlgoList[chooseAlg].Start(Convert.ToInt32(DijkstrastartVertex.Text), Convert.ToInt32(DijkstrafinalVertex.Text));
            }
            else
                MessageBox.Show("Invalid input data");
        }


        private void Button_ReadyExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
            /* int vertex;
             bool isInt = Int32.TryParse(FSstartVertex.Text.ToString(), vertex)
             if ()*/
            if (FSstartVertex.Text != "" && Globals.IsBe(Convert.ToInt32(FSstartVertex.Text)))
            {
                BFS_DFS.Visibility = Visibility.Hidden;
                this.Close();

                AlgoList[chooseAlg].Start(Convert.ToInt32(FSstartVertex.Text));
            }
            else
                MessageBox.Show("Invalid input data");
            
        }
        
        private void Button_ExitAlgoritm_Click(object sender, RoutedEventArgs e)
        {
            if (chooseAlg == 0 || chooseAlg == 1 || chooseAlg == 7)
            {
                BFS_DFS.Visibility = Visibility.Hidden;
                LockPanel.Visibility = Visibility.Hidden;
            }
            else if (chooseAlg == 2)
            {
                Dijkstra.Visibility = Visibility.Hidden;
                LockPanel.Visibility = Visibility.Hidden;
            }
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = Brushes.SkyBlue;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (String.Compare((sender as Button).Tag.ToString(), "Cancel") == 0)
            {
                (sender as Button).Background = (Brush)new BrushConverter().ConvertFrom("#B9C2C2");
            }
            else
            {
                (sender as Button).Background = Brushes.CadetBlue;
            }
        }

        private void FSstartVertex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(FSstartVertex.Text, "[^0-9]"))
                FSstartVertex.Text = FSstartVertex.Text.Remove(FSstartVertex.Text.Length - 1);
        }

        private void DijkstrastartVertex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(DijkstrastartVertex.Text, "[^0-9]"))
                DijkstrastartVertex.Text = DijkstrastartVertex.Text.Remove(DijkstrastartVertex.Text.Length - 1);
        }

        private void DijkstrafinalVertex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(DijkstrafinalVertex.Text, "[^0-9]"))
                DijkstrafinalVertex.Text = DijkstrafinalVertex.Text.Remove(DijkstrafinalVertex.Text.Length - 1);
        }
    }
}
