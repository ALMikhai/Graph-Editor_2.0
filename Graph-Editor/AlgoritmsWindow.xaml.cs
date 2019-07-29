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
using static Graph_Editor.Globals;

namespace Graph_Editor
{
    public partial class AlgoritmsWindow : Window
    {
        int chooseAlg;

        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        
        private void ThemeSettings()
        {
            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();
            logo.Source = bitmap;

            MainWindow.Background           = Themes.AlgoMainWindowColor;

            BFSButton.Background            = Themes.AlgoIsAlgoReady;
            DFSButton.Background            = Themes.AlgoIsAlgoReady;
            DijkstraButton.Background       = Themes.AlgoIsAlgoReady;
            ColorButton.Background          = Themes.AlgoIsAlgoFailed;
            HamiltonianButton.Background    = Themes.AlgoIsAlgoFailed;
            EulerButton.Background          = Themes.AlgoIsAlgoReady;
            FloydButton.Background          = Themes.AlgoIsAlgoReady;
            KruskalButton.Background        = Themes.AlgoIsAlgoReady;
            MaximumButton.Background        = Themes.AlgoIsAlgoReady;

            CancelButton.Background         = Themes.AlgoIsAlgoReadyExitButton;

            Dijkstra.Background             = Themes.AlgoChosenAlgoMainWindow;
            Dijkstra_Label.Background       = Themes.AlgoChosenAlgoNameLabel;
            Dijkstra_Ready.Background       = Themes.AlgoChosenAlgoButtons;
            Dijkstra_Cancel.Background      = Themes.AlgoChosenAlgoButtons;
            DijkstrastartVertex.Background  = Themes.AlgoChosenAlgoVertexWindows;
            DijkstrafinalVertex.Background  = Themes.AlgoChosenAlgoVertexWindows;

            BFS_DFS.Background              = Themes.AlgoChosenAlgoMainWindow;
            FS_Ready.Background             = Themes.AlgoChosenAlgoButtons;
            FS_Cancel.Background            = Themes.AlgoChosenAlgoButtons;
            FSstartVertex.Background        = Themes.AlgoChosenAlgoVertexWindows;
            BFS_DFS_label.Background        = Themes.AlgoChosenAlgoNameLabel;
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

            if (chooseAlg == 0 || chooseAlg == 1)
            {
                BFS_DFS.Visibility = Visibility.Visible;
                FSstartVertex.Text = "0";
                BFS_DFS_label.Content = chooseAlg == 0 ? "BFS" : "DFS";
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
                // 7 - Клускалл
                // 8 - Максимальный поток
                // Здесь нет никаких стартовых вершин, сами номера алгоритмов хранятся в переменной chooseAlg
                // Я так понимаю, ты хотел сделать так: 
                // AlgoList[chooseAlg].Start();
                if (chooseAlg == 7)
                    AlgoList[chooseAlg].Start(0);
                else
                    AlgoList[chooseAlg].Start();

                LockPanel.Visibility = Visibility.Hidden;
                this.Close();
                if (chooseAlg == 6)
                {
                    Graph_Editor.FloydWindow floydWindow = new FloydWindow();
                    floydWindow.ShowDialog();
                }
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
            (sender as Button).Background = Themes.AlgoIsAlgoReadyHover;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = Themes.AlgoIsAlgoReady;
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