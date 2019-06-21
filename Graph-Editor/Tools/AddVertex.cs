using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.Objects;


namespace Graph_Editor
{
    class AddVertex : Tool
    {
        public override void Mouse_Down(Point pntNow)
        {
            Vertex vertexNow = new Vertex(globals.globalIndex++, pntNow);
            globals.vertexData.Add(vertexNow);
        }
    }
}
