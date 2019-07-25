using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Graph_Editor.Objects;
using static Graph_Editor.Globals;

namespace Graph_Editor.Algoritms
{
    public class CheckAndColor : Algoritm
    {
        static bool[] visited = new bool[Globals.Size];
        static int j;
        public override void Start()
        {
            j = -1;
            for (int i = 0; i < VertexData.Count; i++)
            {
                if(!visited[i])
                {
                    j++;
                    foreach (Vertex vertex in VertexData)
                    {
                        if (vertex.Index == i)
                        {
                            vertex.Color = Colors[j];
                            break;
                        }
                    }
                    dfs(i);
                }
            }
            visited = new bool[Globals.Size];
            MainWindow.Instance.Invalidate();
        }
        static void dfs(int v)
        {
            visited[v] = true;
            for (int i = 0; i < Globals.Size; i++)
            {
                if (Globals.Matrix[v, i] != 0 && !visited[i])
                {
                    foreach(Vertex vertex in VertexData)
                    {
                        if(vertex.Index == i)
                        {
                            vertex.Color = Colors[j];
                            break;
                        }
                    }
                    dfs(i);
                }
            }
        }
    }
}
