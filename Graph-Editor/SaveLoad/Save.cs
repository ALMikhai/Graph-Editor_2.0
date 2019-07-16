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
        public static void Save_All()
        {
            if (globals.vertexData.Count != 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Выберете папку для сохранения";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Files(*.bin)|*.bin1";
                sfd.ShowDialog();
                if (sfd.FileName != "")
                { 
                    FileStream fileVertex = (FileStream)sfd.OpenFile();
                    sfd.FileName = sfd.FileName + '2';
                    FileStream fileEdge = (FileStream)sfd.OpenFile();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(fileVertex, globals.vertexData);
                    bin.Serialize(fileEdge, globals.edgesData);
                    fileVertex.Close();
                    fileEdge.Close();
                }
            }
        }
    }
}
