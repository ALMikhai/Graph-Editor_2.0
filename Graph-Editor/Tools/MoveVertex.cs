using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Graph_Editor.Objects;

namespace Graph_Editor
{
    class MoveVertex : Tool
    {
        public override void Mouse_Down(Point pntNow)
        {
            Vertex findedVert;
            foreach(Vertex vert in globals.vertexData)
            {
                if( vert.Coordinates.X - (globals.vertRadius / 2) <= pntNow.X && 
                    pntNow.X <= vert.Coordinates.X + (globals.vertRadius / 2) &&
                    vert.Coordinates.Y - (globals.vertRadius / 2) <= pntNow.Y &&
                    pntNow.Y <= vert.Coordinates.Y + (globals.vertRadius / 2))
                {
                    MessageBox.Show("finded");
                }
            }
            base.Mouse_Down(pntNow);
        }


    }
}
