using System.Windows;

namespace Graph_Editor
{
    public static class ResizeGraph
    {
        static double step = 5;

        public static void IncreaseCanvas(double heightCanvas, double widthCanvas)
        {
            double AbstractHeight = ((heightCanvas * (100 + step)) / 100);
            double AbstractWidth = ((widthCanvas * (100 + step)) / 100);

            double heightScale = AbstractHeight / heightCanvas;
            double widthScale = AbstractWidth / widthCanvas;

            foreach (var vertex in Globals.VertexData.ToArray())
            {
                vertex.Coordinates = new Point(vertex.Coordinates.X * widthScale, vertex.Coordinates.Y * heightScale);
            }
        }

        public static void DecreaseCanvas(double heightCanvas, double widthCanvas)
        {
            double AbstractHeight = ((heightCanvas * (100 - step)) / 100);
            double AbstractWidth = ((widthCanvas * (100 - step)) / 100);

            double heightScale = AbstractHeight / heightCanvas;
            double widthScale = AbstractWidth / widthCanvas;

            foreach(var vertex in Globals.VertexData.ToArray())
            {
                vertex.Coordinates = new Point(vertex.Coordinates.X * widthScale, vertex.Coordinates.Y * heightScale);
            }
        }
    }
}
