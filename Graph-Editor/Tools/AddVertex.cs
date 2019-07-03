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
        Vertex findedVert;

        public override void Mouse_Down(Point pntNow)
        {
            foreach (Vertex vert in Globals.VertexData)
            {
                if (vert.Coordinates.X - (Globals.VertRadius) <= pntNow.X &&
                    pntNow.X <= vert.Coordinates.X + (Globals.VertRadius) &&
                    vert.Coordinates.Y - (Globals.VertRadius) <= pntNow.Y &&
                    pntNow.Y <= vert.Coordinates.Y + (Globals.VertRadius))
                {
                    findedVert = vert;
                    return;
                }
            }
            Vertex vertexNow = new Vertex(Globals.GlobalIndex++, pntNow);
            Globals.VertexData.Add(vertexNow);
        }

        public override void Mouse_Move(Point pntNow)
        {
            if (findedVert != null)
            {
                findedVert.Coordinates = pntNow;
            }
        }

        public override void Mouse_Up()
        {
            findedVert = null;
        }

        public override void Change_Tool()
        {
            findedVert = null;
        }
    }
}
