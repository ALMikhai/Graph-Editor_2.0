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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Graph_Editor.Objects
{
    [Serializable]
    public class Vertex : ISerializable
    {
        private int index;
        private string text = "";
        private Point coordinates;
        private Brush color = OptionsWindow.settings.ColorInsideVertex.Clone();

        public int Index
        {
            set { index = value; }
            get { return index; }
        }

        public Point Coordinates
        {
            get {return coordinates; }
            set { coordinates = value; }
        }

        public Brush Color {
            get { return color; }
            set { color = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Vertex(int number, Point place)
        {
            index = number;
            coordinates = place;
        }

        public Vertex(int number)
        {
            index = number;
        }

        public Vertex(Vertex vertex)
        {
            Index = vertex.Index;
            Coordinates = vertex.Coordinates;
            Color = vertex.Color;
            Text = vertex.Text;
        }

        public Vertex() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("index", index);
            info.AddValue("coordinates", coordinates);
            info.AddValue("color", color.ToString());
            info.AddValue("text", text);
        }

        public Vertex(SerializationInfo info, StreamingContext context)
        {
            index = (int)info.GetValue("index", typeof(int));
            coordinates = (Point)info.GetValue("coordinates", typeof(Point));
            color = (Brush)(new BrushConverter().ConvertFromString((string)info.GetValue("color", typeof(string))));
            text = (string)info.GetValue("text", typeof(string));
        }
    }
}
