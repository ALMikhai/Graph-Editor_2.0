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
    /// Логика взаимодействия для Window3.xaml 
    /// </summary> 
    public partial class DFS : Window
    {
        public DFS()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (startVertex.Text != "")
            {
                Algoritms algoritms = new Algoritms();
                // Запускаем dfs;
                this.Close();
                algoritms.Algoritm_Ready();
            }
            else
            {
                MessageBox.Show("Вы не ввели начальную вершину!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}