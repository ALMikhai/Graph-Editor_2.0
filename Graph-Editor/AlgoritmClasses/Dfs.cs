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

        private static void NextAnimation(Edge e)
        {
            AnimationEdge.edge = e;
            AnimationEdge.Refresh_SrtoryBoard();
            AnimationEdge.Start_animation();
            EventHandler callback = null;
            callback = (o, args) => {
                MainWindow.Instance.InvalidateAlgo(e);
                edgesUsed.Remove(edgesUsed[0]);
                AnimationEdge.storyboard.Completed -= callback;
                if (edgesUsed.Count > 0)
                {
                    NextAnimation(edgesUsed[0]);
                }
            };
            AnimationEdge.storyboard.Completed += callback;
        }

        public static void Start(int v)
        {
            dfs(v);
            NextAnimation(edgesUsed[0]);
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
                            edge.Color = Brushes.Red;
                            if(!edge.Directed)
                            {
                                foreach(var e in globals.edgesData)
                                {
                                    if(e.From.Index == i && e.To.Index == v)
                                    {
                                        e.Color = Brushes.Red;
                                        break;
                                    }
                                }
                            }
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
