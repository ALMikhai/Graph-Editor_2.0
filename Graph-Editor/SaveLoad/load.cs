using System;
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
    static public class Load
    {
        public static void Loaded()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Files(*.bin1)|*.bin1",
                Title = "Открыть файл .bin1"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                try
                {
                    Stream file = (FileStream)fileDialog.OpenFile();
                    BinaryFormatter deserializer = new BinaryFormatter();

                    Globals.VertexData = (List<Vertex>)deserializer.Deserialize(file);
                    file.Close();

                    fileDialog.FileName = fileDialog.FileName + '2';

                    file = (FileStream)fileDialog.OpenFile();
                    Globals.EdgesData = (List<Edge>)deserializer.Deserialize(file);
                    file.Close();

                    MainWindow.Instance.Invalidate();

                    Globals.RestoreMatrix();
                }
                catch
                {
                    Globals.VertexData.Clear();
                    Globals.EdgesData.Clear();
                    Globals.RestoreMatrix();

                    Globals.GlobalIndex = 0;

                    MainWindow.Instance.Invalidate();

                    MessageBox.Show("Не удалось открыть файл");
                }
            }
        }
    }
}
