using System;
using System.Collections.Generic;
using Graph_Editor.Objects;

namespace Graph_Editor.Algoritms
{
    public class Dfs : Algoritm
    {
        static bool[] visited = new bool[Globals.Size];
        static List<Edge> edgesUsed = new List<Edge>();

        public override void Start(int v)
        {
            MainWindow.Instance.Invalidate();
            if (!Globals.CheckIn(v))
                return;
            dfs(v);
            AnimationEdge.NextAnimation(edgesUsed[0],edgesUsed);
            visited = new bool[Globals.Size];
        }

        static void dfs(int v)
        {
            visited[v] = true;
            for (int i = 0; i < Globals.Size; i++)
            {
                if (Globals.Matrix[v, i] != 0 && !visited[i])
                {
                    foreach (var edge in Globals.EdgesData)
                    {
                        if (edge.From.Index == v && edge.To.Index == i)
                        { 
                            edgesUsed.Add(edge);
                            break;
                        }
                    }
                    dfs(i);
                }
            }
        }
    }
}
