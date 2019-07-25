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

namespace Graph_Editor.SaveLoad
{
    public static class LoadOptions
    {
        private static string path = "../../SaveLoad/settings.bin";

        public static void Load()
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                FileName = path,
            };

            Stream loadFile = (FileStream)fileDialog.OpenFile();

            BinaryFormatter bin = new BinaryFormatter();

            OptionsWindow.settings = (Settings)bin.Deserialize(loadFile);

            loadFile.Close();
        }
    }
}
