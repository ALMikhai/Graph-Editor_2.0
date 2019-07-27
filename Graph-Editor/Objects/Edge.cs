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
    public class Edge : ISerializable
    {
        private Vertex from, to;
        private int weight;
        private bool directed;
        private Brush color = OptionsWindow.settings.ColorEdge;
        private double thickness = Globals.ThicknessEdge;

        public Vertex From
        {
            set { from = value; }
            get { return from; }
        }

        public Vertex To
        {
            set { to = value; }
            get { return to; }
        }

        public int FromIndex
        {
            get;
        }

        public int ToIndex
        {
            get;
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public bool Directed
        {
            get { return directed; }
            set { directed = value; }
        }

        public Brush Color
        {
            get { return color; }
            set { color = value; }
        }

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public Edge(Vertex from, Vertex to, int weight, bool directed, Brush color, double thickness)
        {
            From = from;
            To = to;
            FromIndex = from.Index;
            ToIndex = to.Index;
            Weight = weight;
            Directed = directed;
            Color = color;
            Thickness = thickness;
        }

        public Edge(Edge edge)
        {
            From = new Vertex(edge.From);
            To = new Vertex(edge.To);
            FromIndex = edge.FromIndex;
            ToIndex = edge.ToIndex;
            Weight = edge.Weight;
            Directed = edge.Directed;
            Color = edge.Color;
            Thickness = edge.Thickness;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("from", FromIndex);
            info.AddValue("to", ToIndex);
            info.AddValue("weight", weight);
            info.AddValue("directed", directed);
            info.AddValue("color", color.ToString());
            info.AddValue("thickness", thickness);
        }

        public Edge(SerializationInfo info, StreamingContext context)
        {
            FromIndex = (int)info.GetValue("from", typeof(int));
            ToIndex = (int)info.GetValue("to", typeof(int));
            weight = (int)info.GetValue("weight", typeof(int));
            directed = (bool)info.GetValue("directed", typeof(bool));
            color = (Brush)(new BrushConverter().ConvertFromString((string)info.GetValue("color", typeof(string))));
            thickness = (double)info.GetValue("thickness", typeof(double));
        }

        public Edge() { }
    }
}
