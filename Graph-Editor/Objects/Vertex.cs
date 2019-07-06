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
        private readonly int index;
        private Point coordinates;
        private Brush color = Globals.StrokeColor;

        public int Index
        {
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

        public Vertex(int number, Point place)
        {
            index = number;
            coordinates = place;
        }

        public Vertex(int number)
        {
            index = number;
        }

        public Vertex() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("index", index);
            info.AddValue("coordinates", coordinates);
        }

        public Vertex(SerializationInfo info, StreamingContext context)
        {
            index = (int)info.GetValue("index", typeof(int));
            coordinates = (Point)info.GetValue("coordinates", typeof(Point));
        }
    }
}
