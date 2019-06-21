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
        public void Algoritm_Ready()
        {
            // TODO: Доработать разблокировку окна (Algoritms)
            // LockPanel.Background = null;
            // LockPanel.Opacity = 0;
            // LockPanel.Visibility = Visibility.Hidden;

            mainWindow.WaitPanel.Background = null;
            mainWindow.WaitPanel.Opacity = 0;

            mainWindow.Activate();
        }
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            mainWindow.WaitPanel.Background = null;
            mainWindow.WaitPanel.Opacity = 0;
        }

        private void BSF_Button_Click(object sender, RoutedEventArgs e)
        {
            LockPanel.Background = Brushes.Gray;
            BFS.Visibility = Visibility.Visible;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            LockPanel.Background = null;
            BFS.Visibility = Visibility.Hidden;
        }

        private void BFS_Ready_Click(object sender, RoutedEventArgs e)
        {
            if (startVertex.Text != "")
            {
               // foreach()
                //{

                //
            }
        }
        
        private void BFS_Cancle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
