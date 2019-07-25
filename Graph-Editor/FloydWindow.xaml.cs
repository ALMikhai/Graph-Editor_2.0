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
using System.Windows.Shapes;

namespace Graph_Editor
{
    /// <summary>
    /// Логика взаимодействия для FloydWindow.xaml
    /// </summary>
    public partial class FloydWindow : Window
    {
        public static int[,] matrix;
        private int[] maxLength = new int[Globals.GlobalIndex];
        public FloydWindow()
        {
            InitializeComponent();

            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                sideTextBox.Text += i.ToString() + "\n";
            }
            
            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                for (int j = 0; j < Globals.GlobalIndex; j++)
                {
                    maxLength[i] = 1;
                    if (maxLength[i] < matrix[i, j].ToString().Length)
                    {

                    }
                }
            }


            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                topTextBox.Text += i.ToString();
                /*while (maxLength != 0)
                {
                    topTextBox.Text += " ";
                    maxLength--;
                }*/
            }

            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                int currentLength = 1;
                for (int j = 0; j < Globals.GlobalIndex; j++)
                {
                    if (currentLength < (int)Math.Log10(matrix[i, j]) + 1)
                    {
                        currentLength = (int)Math.Log10(matrix[i, j]) + 1;
                    }
                }
                for (int j = 0; j < Globals.GlobalIndex; j++)
                {
                    mainTextBox.Text += matrix[i, j].ToString();
                }
                mainTextBox.Text += "\n";
            }
        }
    }
}
