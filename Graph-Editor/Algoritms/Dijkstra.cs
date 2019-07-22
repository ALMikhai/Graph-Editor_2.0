using System;
using System.Collections.Generic;
using Graph_Editor.Objects;

namespace Graph_Editor.Algoritms
{
    public class Dijkstra : Algoritm
    {
        static bool[] visited = new bool[Globals.Size];
        static List<Edge> path = new List<Edge>();
        static int[] destinations = new int[Globals.Size];
        public override void Start(int s, int e)
        {
            MainWindow.Instance.Invalidate();
            if (!Globals.CheckIn(s) || !Globals.CheckIn(e))
                return;
            dijkstra(s, e);
        }

        static void dijkstra(int s, int e)
        {
            foreach (int i in destinations)
                destinations[i] = 9999999;

            
        }
    }
}
