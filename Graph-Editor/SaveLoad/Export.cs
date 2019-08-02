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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Graph_Editor.SaveLoad
{
    public static class Export
    {
        public static void ExportPng(object s, RoutedEventArgs e)
        {
            if (Globals.AnimationsNow.Count != 0)
            {
                return;
            }

            MainWindow.Instance.Visibility = Visibility.Hidden;

            Thickness margin = MainWindow.Instance.GraphCanvas.Margin;

            MainWindow.Instance.GraphCanvas.Margin = new Thickness(0, 0, 0, 0);

            int Height = (int)MainWindow.Instance.GraphCanvas.ActualHeight;
            int Width = (int)MainWindow.Instance.GraphCanvas.ActualWidth;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Сохранить как",
                OverwritePrompt = true,
                CheckPathExists = true,
                Filter = "Files(*.png)|*.png"
            };

            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                Size size = new Size(Width, Height);
                MainWindow.Instance.GraphCanvas.Measure(size);

                MainWindow.Instance.GraphCanvas.Arrange(new Rect(size));

                var rtb = new RenderTargetBitmap(Width, Height, 96, 96, PixelFormats.Pbgra32);
                rtb.Render(MainWindow.Instance.GraphCanvas);
                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(rtb));
                FileStream file = (FileStream)sfd.OpenFile();
                png.Save(file);
                file.Close();
            }

            MainWindow.Instance.GraphCanvas.Margin = margin;

            MainWindow.Instance.Visibility = Visibility.Visible;
        }
    }
}
