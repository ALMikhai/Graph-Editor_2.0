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
    /// Логика взаимодействия для Set_Graph.xaml
    /// </summary>
    public partial class SetGraph : Window
    {
        private void ThemeSettings()
        {
            myWindow.Icon = new BitmapImage(new Uri(Themes.logoPath, UriKind.Relative));

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Themes.logoPath, UriKind.Relative);
            bitmap.EndInit();

            logo.Source = bitmap;
        }
        public SetGraph()
        {
            InitializeComponent();

            ThemeSettings();

            Instructions.Text = "Style of code: First vertex -> Second vertex -> Weight\n" +
                "Implementation:\n" + "1 2 15 \n2 3 7\n3 6 25";
        }

        private void Parametrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Parametrs.Text, "[^0-9 \n]"))
                Parametrs.Text = Parametrs.Text.Remove(Parametrs.Text.Length - 1);
        }

        private void Parametrs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Parametrs.Text = "\n" + Parametrs.Text;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Parametrs.Text = "";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Делаешь своё
            this.Close();
        }
    }
}
