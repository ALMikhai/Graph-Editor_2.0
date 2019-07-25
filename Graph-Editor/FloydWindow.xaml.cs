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

        private void ThemeSetting()
        {
            myWindow.Icon               = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            fullWindow.Background       = Themes.FloydMainWindow;
            mainTextBox.Background      = Themes.FloydTextBlocks;
            topTextBox.Background       = Themes.FloydTextBlocks;
            sideTextBox.Background      = Themes.FloydTextBlocks;

        }
        public FloydWindow()
        {
            InitializeComponent();

            ThemeSetting();

            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                sideTextBox.Text += i.ToString() + "\n";
            }


            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                topTextBox.Text += i.ToString();
                int currentMaxLength = 0;
                for (int j = 0; j < Globals.GlobalIndex; j++)
                {
                    for (int k = 0; k < Globals.GlobalIndex; k++)
                    {
                        if (currentMaxLength < matrix[j, k].ToString().Length)
                            currentMaxLength = matrix[j, k].ToString().Length;
                    }
                }
                topTextBox.Text += " ";
                for (; currentMaxLength > 1; currentMaxLength--)
                {
                    topTextBox.Text += " ";
                    topTextBox.Text += " ";
                }
            }

            for (int i = 0; i < Globals.GlobalIndex; i++)
            {
                for (int j = 0; j < Globals.GlobalIndex; j++)
                {
                    mainTextBox.Text += matrix[i, j].ToString();
                    int currentMaxLength = 0;
                    for (int k = 0; k < Globals.GlobalIndex; k++)
                    {
                        if (currentMaxLength < matrix[j, k].ToString().Length)
                            currentMaxLength = matrix[j, k].ToString().Length;
                    }
                    mainTextBox.Text += " ";
                    for (;currentMaxLength - (matrix[i, j].ToString().Length) != 0; currentMaxLength--)
                    {
                        mainTextBox.Text += " ";
                        mainTextBox.Text += " ";
                    }
                }
                mainTextBox.Text += "\n";
            }
        }
    }
}
