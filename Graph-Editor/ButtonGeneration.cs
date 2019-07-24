using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Graph_Editor.Objects;
using Graph_Editor.PropertiesWindow;

namespace Graph_Editor
{
    public static class ButtonGeneration
    {
        public static void ColorButtonGeneration()
        {
            foreach (var color in Globals.Colors)
            {
                Button newButton = new Button
                {
                    Height = 18,
                    Width = 18,
                    Background = color,
                    Tag = "0",
                    Margin = new Thickness(2.5)
                };

                newButton.Click += MainWindow.Instance.ChangeColor;

                MainWindow.Instance.colorbarPanel.Items.Add(newButton);
            }
        }
    }
}
