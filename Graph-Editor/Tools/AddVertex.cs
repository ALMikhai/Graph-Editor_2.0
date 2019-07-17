using Graph_Editor.Objects;
using Graph_Editor.UndoRedo;
using System.Windows;


namespace Graph_Editor
{
    class AddVertex : Tool
    {
        Vertex findedVert;

        public override void Mouse_Down(Point pointNow)
        {
            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Coordinates.X - (Globals.VertRadius) <= pointNow.X &&
                    pointNow.X <= vertex.Coordinates.X + (Globals.VertRadius) &&
                    vertex.Coordinates.Y - (Globals.VertRadius) <= pointNow.Y &&
                    pointNow.Y <= vertex.Coordinates.Y + (Globals.VertRadius))
                {
                    findedVert = vertex;
                    return;
                }
            }

            Vertex newVertex = new Vertex(Globals.GlobalIndex++, pointNow);
            Globals.VertexData.Add(newVertex);

            History.Add(null, newVertex);
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
