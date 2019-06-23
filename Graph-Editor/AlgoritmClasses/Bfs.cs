using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Graph_Editor.globals;

namespace Graph_Editor.AlgoritmClasses
{
    public class Bfs
    {
        static bool[] visited = new bool[globals.Size];

        static Queue<int> q = new Queue<int>();

        public static void Start(int v)
        {
            q.Enqueue(v);
            visited[v] = true;
            while (q.Count != 0)
            {
                int vt = q.Dequeue();
                for(int i = 0; i < Size; i++)
                {
                    if(matrix[vt,i] != 0 && !visited[i])
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                        MainWindow.Instance.Invalidate();
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}