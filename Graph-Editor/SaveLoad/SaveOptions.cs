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
    public static class SaveOptions
    {
        private static string path = "../../SaveLoad/settings.bin";
        public static void Save()
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                FileName = path,
            };

            FileStream saveFile = (FileStream)fileDialog.OpenFile();

            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(saveFile, OptionsWindow.settings);

            saveFile.Close();
        }
    }
}
