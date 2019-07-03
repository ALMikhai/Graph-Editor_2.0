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
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Files(*.bin1)|*.bin1",
                Title = "Открыть файл .bin1"
            };
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                Stream file = (FileStream)ofd.OpenFile();
                BinaryFormatter deserializer = new BinaryFormatter();

                Globals.VertexData = (List<Vertex>)deserializer.Deserialize(file);
                file.Close();

                ofd.FileName = ofd.FileName + '2';

                file = (FileStream)ofd.OpenFile();
                Globals.EdgesData = (List<Edge>)deserializer.Deserialize(file);
                file.Close();

                MainWindow.Instance.Invalidate();

                Globals.RestoreMatrix();
            }
        }
    }
}
