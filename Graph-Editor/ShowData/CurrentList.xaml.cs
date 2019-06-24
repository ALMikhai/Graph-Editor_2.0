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
    public partial class CurrentList : Window
    {
        public CurrentList()
        {
            InitializeComponent();
            for (int i = 0; i < globals.vertexData.Count(); i++)
            {
                sideBlock.Text += i + "\n";
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
