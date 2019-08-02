using Graph_Editor.Objects;
using Graph_Editor.UndoRedo;
using System.Windows;

namespace Graph_Editor
{
    class AddVertex : Tool
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
                    return;
                }
            }

            Vertex newVertex = new Vertex(Globals.GlobalIndex, pointNow);
            Globals.VertexData.Add(new Vertex(newVertex));

            History.Add(null, newVertex);
        }
    }
}
