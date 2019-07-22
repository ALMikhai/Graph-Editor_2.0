using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Objects;
using Graph_Editor.UndoRedo;
using Graph_Editor.PropertiesWindow;
using System.Windows;

namespace Graph_Editor
{
    class EditVertexEdge : Tool
    {
        public override void Mouse_Down(Point pointNow)
        {
            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Coordinates.X - (Globals.VertRadius) <= pointNow.X &&
                    pointNow.X <= vertex.Coordinates.X + (Globals.VertRadius) &&
                    vertex.Coordinates.Y - (Globals.VertRadius) <= pointNow.Y &&
                    pointNow.Y <= vertex.Coordinates.Y + (Globals.VertRadius))
                {
                    VertexProrerty.PropertiesVertexWindow(vertex);
                    return;
                }
            }
        }
    }
}
