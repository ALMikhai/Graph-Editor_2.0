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
        public CurrentMatrix()
        {
            InitializeComponent();
            if (globals.vertexData.Count() == 0)
            {
                i_j.Content = " ";
                i_j.BorderBrush = Brushes.Transparent;
            }

            for (int i = 0; i < globals.vertexData.Count(); i++)
                topBlock.Text += i.ToString() + " ";
            for (int i = 0; i < globals.vertexData.Count(); i++)
                sideBlock.Text += i.ToString() + "\n";

            for (int i = 0; i < globals.vertexData.Count(); i++)
            {
                for (int j = 0; j < globals.vertexData.Count(); j++)
                {
                    if (j >= 10)
                        mainBlock.Text += "  ";
                    mainBlock.Text += globals.matrix[i, j] != 0 ? 1 : 0;
                    mainBlock.Text += " ";
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
