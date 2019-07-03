using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Graph_Editor.Globals;
using Graph_Editor.Objects;

namespace Graph_Editor.AlgoritmClasses
{
    public class Bfs
    {
        static bool[] visited = new bool[Size];

        static Queue<int> q = new Queue<int>();

        public static List<Edge> edgesUsed = new List<Edge>();
        public static void Start(int v)
        {
            MainWindow.Instance.Invalidate();
            if (!CheckIn(v))
                return;
            bfs(v);
            AnimationEdge.NextAnimation(edgesUsed[0], edgesUsed);
            visited = new bool[Size];
        }
        static void bfs(int v)
        {
            
            q.Enqueue(v);
            visited[v] = true;
            while (q.Count != 0)
            {
                int vt = q.Dequeue();
                for (int i = 0; i < Size; i++)
                {
                    if (Matrix[vt, i] != 0 && !visited[i])
                    {
                        foreach (var edge in EdgesData)
                        {
                            if (edge.From.Index == vt && edge.To.Index == i)
                            {
                                edgesUsed.Add(edge);
                                break;
                            }
                        }
                        q.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
    }
}