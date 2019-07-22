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
        private Brush color = Themes.ColorEdge;
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
            Weight = weight;
            Directed = directed;
            Color = color;
            Thickness = thickness;
        }

        public Edge(Edge edge)
        {
            From = new Vertex(edge.From);
            To = new Vertex(edge.To);
            Weight = edge.Weight;
            Directed = edge.Directed;
            Color = edge.Color;
            Thickness = edge.Thickness;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("index", Globals.GlobalIndex);
            info.AddValue("from", from.Index);
            info.AddValue("to", to.Index);
            info.AddValue("weight", weight);
            info.AddValue("directed", directed);
            info.AddValue("color", color.ToString());
            info.AddValue("thickness", thickness);
        }

        public Edge(SerializationInfo info, StreamingContext context)
        {
            Globals.GlobalIndex = (int)info.GetValue("index", typeof(int));

            int index = (int)info.GetValue("from", typeof(int));
            
            foreach(var vertex in Globals.VertexData)
            {
                if(vertex.Index == index)
                {
                    from = vertex;
                    break;
                }
            }

            index = (int)info.GetValue("to", typeof(int));

            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Index == index)
                {
                    to = vertex;
                    break;
                }
            }

            weight = (int)info.GetValue("weight", typeof(int));
            directed = (bool)info.GetValue("directed", typeof(bool));
            color = (Brush)(new BrushConverter().ConvertFromString((string)info.GetValue("color", typeof(string))));
            thickness = (double)info.GetValue("thickness", typeof(double));
        }

        public Edge() { }
    }
}
