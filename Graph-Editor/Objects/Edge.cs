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
        private readonly Vertex from, to;
        private int weight;
        private bool directed;
        private Brush color = Globals.StrokeColor;

        public Vertex From
        {
            get { return from; }
        }

        public Vertex To
        {
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

        public Edge(Vertex first, Vertex second, int w, bool state)
        {
            from = first;
            to = second;
            weight = w;
            directed = state;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("index", Globals.GlobalIndex);
            info.AddValue("from", from.Index);
            info.AddValue("to", to.Index);
            info.AddValue("weight", weight);
            info.AddValue("directed", directed);
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
        }

        public Edge() { }
    }
}
