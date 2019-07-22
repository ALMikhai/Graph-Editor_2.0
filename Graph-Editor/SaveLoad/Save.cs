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
                    Filter = "Files(*.bin)|*.bin1"
                };

                fileDialog.ShowDialog();

                if (fileDialog.FileName != "")
                { 
                    FileStream fileVertex = (FileStream)fileDialog.OpenFile();

                    fileDialog.FileName = fileDialog.FileName + '2';
                    FileStream fileEdge = (FileStream)fileDialog.OpenFile();

                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(fileVertex, Globals.VertexData);
                    bin.Serialize(fileEdge, Globals.EdgesData);

                    fileVertex.Close();
                    fileEdge.Close();
                }
            }
        }
    }
}
