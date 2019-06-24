using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Threading;
using Graph_Editor.Objects;

namespace Graph_Editor.AlgoritmClasses
{
    public static class Dfs
    {
        static bool[] visited = new bool[globals.Size];

        public static List<Edge> edgesUsed = new List<Edge>();

        public static void Start(int v)
        {
            
            MainWindow.Instance.Invalidate();
            if (!globals.CheckIn(v))
                return;
            dfs(v);
            AnimationEdge.NextAnimation(edgesUsed[0],edgesUsed);
            visited = new bool[globals.Size];
        }

        static void dfs(int v)
        {
            visited[v] = true;
            for (int i = 0; i < globals.Size; i++)
            {
                if (globals.matrix[v, i] != 0 && !visited[i])
                {
                    foreach (var edge in globals.edgesData)
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
