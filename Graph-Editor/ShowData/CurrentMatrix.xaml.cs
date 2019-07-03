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
            for (int i = 0; i < Globals.VertexData.Count(); i++)
                topBlock.Text += i.ToString() + " ";
            for (int i = 0; i < Globals.VertexData.Count(); i++)
                sideBlock.Text += i.ToString() + "\n";

            for (int i = 0; i < Globals.VertexData.Count(); i++)
            {
                for (int j = 0; j < Globals.VertexData.Count(); j++)
                {
                    mainBlock.Text += Globals.Matrix[i, j] != 0 ? 1 : 0;
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
