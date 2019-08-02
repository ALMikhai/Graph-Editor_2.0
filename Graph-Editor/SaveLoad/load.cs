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
                Filter = "Files(*.bin)|*.bin",
                Title = "Открыть файл .bin"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                try
                {
                    MainWindow.Instance.ClearAll_Click(new object(), new System.Windows.RoutedEventArgs());

                    Stream file = (FileStream)fileDialog.OpenFile();

                    BinaryFormatter deserializer = new BinaryFormatter();

                    List<object> toLoad = new List<object>();

                    toLoad = (List<object>)deserializer.Deserialize(file);

                    List<Vertex> toLoadVertexData = (List<Vertex>)toLoad[0];
                    List<Edge> toLoadEdgesData = (List<Edge>)toLoad[1];

                    foreach(var vertex in toLoadVertexData)
                    {
                        Globals.VertexData.Add(new Vertex(vertex));
                        //Globals.GlobalIndex++;
                    }

                    foreach(var edge in toLoadEdgesData)
                    {
                        Globals.EdgesData.Add(new Edge(Globals.FindVertex(edge.FromIndex), Globals.FindVertex(edge.ToIndex), edge.Weight, edge.Directed, edge.Color, edge.Thickness));
                    }

                    Globals.RestoreMatrix();

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
                }
                catch
                {
                    Globals.VertexData.Clear();
                    Globals.EdgesData.Clear();
                    Globals.RestoreMatrix();

                    //Globals.GlobalIndex = 0;

                    MainWindow.Instance.Invalidate();

                    MessageBox.Show("Не удалось открыть файл");
                }
            }
        }
    }
}
