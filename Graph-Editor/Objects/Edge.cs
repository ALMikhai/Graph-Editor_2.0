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
namespace Graph_Editor.Objects
{
    public class Edge
    {
        private Vertex from, to;
        private int weight;
        private bool directed;

        public Vertex From
        {
            get
            {
                return from;
            }
        }
        public Vertex To
        {
            get
            {
                return to;
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
        }
        public bool Directed
        {
            get
            {
                return directed;
            }
        }


        public Edge(Vertex first, Vertex second, int w, bool state) { from = first; to = second; weight = w; directed = state; }
    }
}
