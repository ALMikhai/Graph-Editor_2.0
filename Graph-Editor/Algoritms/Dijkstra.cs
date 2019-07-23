using System;
using System.Collections.Generic;
using Graph_Editor.Objects;
using static Graph_Editor.Globals;

namespace Graph_Editor.Algoritms
{
    class MinHeap<T> where T : IComparable<T>
    {
        private List<T> array = new List<T>();

        public void Add(T element)
        {
            array.Add(element);
            int c = array.Count - 1;
            while (c > 0 && array[c].CompareTo(array[c / 2]) == -1)
            {
                T tmp = array[c];
                array[c] = array[c / 2];
                array[c / 2] = tmp;
                c = c / 2;
            }
        }

        public T RemoveMin()
        {
            T ret = array[0];
            array[0] = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);

            int c = 0;
            while (c < array.Count)
            {
                int min = c;
                if (2 * c + 1 < array.Count && array[2 * c + 1].CompareTo(array[min]) == -1)
                    min = 2 * c + 1;
                if (2 * c + 2 < array.Count && array[2 * c + 2].CompareTo(array[min]) == -1)
                    min = 2 * c + 2;

                if (min == c)
                    break;
                else
                {
                    T tmp = array[c];
                    array[c] = array[min];
                    array[min] = tmp;
                    c = min;
                }
            }

            return ret;
        }

        public T Peek()
        {
            return array[0];
        }

        public int Count
        {
            get
            {
                return array.Count;
            }
        }
    }

    class PriorityQueue<T>
    {
        internal class Node : IComparable<Node>
        {
            public int Priority;
            public T O;
            public int CompareTo(Node other)
            {
                return Priority.CompareTo(other.Priority);
            }
        }

        private MinHeap<Node> minHeap = new MinHeap<Node>();

        public void Add(int priority, T element)
        {
            minHeap.Add(new Node() { Priority = priority, O = element });
        }

        public T RemoveMin()
        {
            return minHeap.RemoveMin().O;
        }

        public T Peek()
        {
            return minHeap.Peek().O;
        }

        public int Weight()
        {
            return minHeap.Peek().Priority;
        }

        public int Count
        {
            get
            {
                return minHeap.Count;
            }
        }
    }

    public class Dijkstra : Algoritm
    {
        static bool[] visited = new bool[Size];
        static List<Edge> path = new List<Edge>();
        static int[] destinations = new int[Size];
        static int[] p = new int[Size];

        static bool IsWay(int v, int end)
        {
            if (v == end)
                return true;
            visited[v] = true;
            for (int i = 0; i < Size; i++)
            {
                if (Matrix[v, i] != 0 && !visited[i])
                {
                    if(IsWay(i, end))
                        return true;
                }
            }
            return false;
        }
        public override void Start(int s, int e)
        {
            MainWindow.Instance.Invalidate();
            if (!CheckIn(s) || !CheckIn(e) /*|| !IsWay(s, e)*/)
                return;

            dijkstra(s, e);
            AnimationEdge.NextAnimation(path[0], path);
        }

        static void dijkstra(int start, int end)
        {
            for (int k = 0; k < Size; k++)
            {
                destinations[k] = 99999999;
                p[k] = 0;
            }
                
            destinations[start] = 0;

            PriorityQueue<int> q = new PriorityQueue<int>();
            q.Add(0, start);
            while(q.Count != 0)
            {
                int v = q.Peek(), w = q.Weight(); q.RemoveMin();
                if (w > destinations[v] || visited[v]) continue;

                for (int i = 0; i < Size; i++)
                {
                    if(Matrix[v,i] != 0)
                    {
                        if (destinations[v] + Matrix[v,i] < destinations[i])
                        {
                            destinations[i] = destinations[v] + Matrix[v, i];
                            p[i] = v;
                            q.Add(Matrix[v, i], i);
                        }
                        visited[v] = true;
                    }
                }
            }
            visited = new bool[Size];
            int j;
            for (j = end; j != start; j = p[j])
            {
                foreach(Edge edge in EdgesData)
                {
                    if (edge.From.Index == p[j] && edge.To.Index == j)
                    {
                        path.Add(edge);
                        break;
                    }
                }
            }
            foreach (Edge edge in EdgesData)
            {
                if (edge.From.Index == start && edge.To.Index == j)
                {
                    path.Add(edge);
                    break;
                }
            }

            path.Reverse();
        }
    }
}
