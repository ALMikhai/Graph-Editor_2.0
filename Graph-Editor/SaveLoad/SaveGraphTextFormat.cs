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
using System.Drawing.Drawing2D;
using System.Windows.Media.Animation;
using System.Threading;
using System.Diagnostics;
using Graph_Editor.Algoritms;
using System.ComponentModel;
using Graph_Editor.ShowData;
using Graph_Editor.UndoRedo;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Graph_Editor.SaveLoad
{
    public static class SaveGraphTextFormat
    {
        public static void Save(object s, RoutedEventArgs e)
        {
            if (Globals.AnimationsNow.Count != 0)
            {
                return;
            }
            if (Globals.VertexData.Count != 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog()
                {
                    Title = "Выберете папку для сохранения",
                    OverwritePrompt = true,
                    CheckPathExists = true,
                    Filter = "Files(*.txt)|*.txt"
                };

                fileDialog.ShowDialog();

                if (fileDialog.FileName != "")
                {
                    StreamWriter writer = new StreamWriter(fileDialog.FileName, false, Encoding.Default);

                    writer.WriteLine(Globals.VertexData.Count);
                    writer.WriteLine(Globals.EdgesData.Count);

                    foreach(var edge in Globals.EdgesData)
                    {
                        string line = edge.From.Index.ToString() + ' ' + edge.To.Index.ToString() + ' ' + edge.Weight.ToString();
                        writer.WriteLine(line);
                    }

                    writer.Close();
                }
            }
        }
    }
}
