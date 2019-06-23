﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Objects;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Graph_Editor
{
    public class Exit
    {
        public static int choose;
        public static void Exit_and_Save_All()
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            if (choose == 0)
            {
                Save.Save_All();
            }
            else if (choose == 1)
            {
                mainWindow.Close();
            }
            else if (choose == 2)
            {
                mainWindow.Exit_Dialog.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
