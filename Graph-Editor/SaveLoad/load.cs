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
using Graph_Editor.UndoRedo;

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
                    MainWindow.Instance.ClearAll_Click(new object(), new System.Windows.RoutedEventArgs());

                    Stream file = (FileStream)fileDialog.OpenFile();
                    BinaryFormatter deserializer = new BinaryFormatter();

                    Globals.VertexData = (List<Vertex>)deserializer.Deserialize(file);
                    file.Close();

                    fileDialog.FileName = fileDialog.FileName + '2';

                    file = (FileStream)fileDialog.OpenFile();
                    Globals.EdgesData = (List<Edge>)deserializer.Deserialize(file);
                    file.Close();

                    MainWindow.Instance.Invalidate();

                    List<Vertex> vertices = new List<Vertex>();
                    foreach (var vertex in Globals.VertexData)
                    {
                        vertices.Add(new Vertex(vertex));
                    }

                    List<Edge> edges = new List<Edge>();
                    foreach (var edge in Globals.EdgesData)
                    {
                        edges.Add(new Edge(edge));
                    }

                    History.Add(edges, vertices);
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
