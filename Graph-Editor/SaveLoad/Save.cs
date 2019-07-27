using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Objects;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Graph_Editor
{ 
    public class Save
    {
        public static void SaveAll()
        {
            if (Globals.VertexData.Count != 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog()
                {
                    Title = "Выберете папку для сохранения",
                    OverwritePrompt = true,
                    CheckPathExists = true,
                    Filter = "Files(*.bin)|*.bin"
                };

                fileDialog.ShowDialog();

                if (fileDialog.FileName != "")
                {
                    FileStream fileVertex = (FileStream)fileDialog.OpenFile();

                    try
                    {
                        BinaryFormatter bin = new BinaryFormatter();

                        List<object> toSave = new List<object>();

                        toSave.Add(Globals.VertexData);
                        toSave.Add(Globals.EdgesData);

                        bin.Serialize(fileVertex, toSave);

                        fileVertex.Close();
                    }
                    catch
                    {
                        fileVertex.Close();
                    }
                }
            }
        }
    }
}
