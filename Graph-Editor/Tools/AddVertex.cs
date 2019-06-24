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
            foreach (Vertex vert in globals.vertexData)
            {
                if (vert.Coordinates.X - (globals.vertRadius) <= pntNow.X &&
                    pntNow.X <= vert.Coordinates.X + (globals.vertRadius) &&
                    vert.Coordinates.Y - (globals.vertRadius) <= pntNow.Y &&
                    pntNow.Y <= vert.Coordinates.Y + (globals.vertRadius))
                {
                    findedVert = vert;
                    return;
                }
            }
            Vertex vertexNow = new Vertex(globals.globalIndex++, pntNow);
            globals.vertexData.Add(vertexNow);
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

        public override void Mouse_Leave()
        {
            findedVert = null;
        }

        public override void Change_Tool()
        {
            findedVert = null;
        }
    }
}
