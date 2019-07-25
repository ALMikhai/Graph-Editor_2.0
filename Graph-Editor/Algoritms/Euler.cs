using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Graph_Editor.Globals;
using Graph_Editor.Objects;

namespace Graph_Editor.Algoritms
{
    public class Euler : Algoritm
    {
        static List<Edge> edgesUsed = new List<Edge>();

        static Stack<int> st = new Stack<int>();

        static int[] deg = new int[Size];

        static List<int> res = new List<int>();

        static int[,] matrix = new int[Size, Size];
        public override void Start()
        {
            MainWindow.Instance.Invalidate();
            if(euler())
                gAnim.NextAnimation(edgesUsed[0], edgesUsed);

            st = new Stack<int>();
            res = new List<int>();
            deg = new int[Size];
        }

        static bool euler()
        {
            Array.Copy(Matrix, matrix, Size * Size);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (matrix[i, j] != 0)
                        deg[i]++;
                }
            }

            int first = 0;
            while (deg[first] == 0) ++first;

            int v1 = -1, v2 = -1;
            bool bad = false;
            for (int i = 0; i < Size; ++i)
                if (deg[i] % 2 != 0)
                    if (v1 == -1)
                        v1 = i;
                    else if (v2 == -1)
                        v2 = i;
                    else
                        bad = true;
            if (v1 != -1)
            {
                ++matrix[v1, v2];
                ++matrix[v2, v1];
            }

            st.Push(first);

            while (st.Count != 0)
            {
                int v = st.Peek();
                int i;
                for (i = 0; i < Size; ++i)
                    if (matrix[v, i] != 0)
                        break;
                if (i == Size)
                {
                    res.Add(v);
                    st.Pop();
                }
                else
                {
                    matrix[v, i] = 0;
                    matrix[i, v] = 0;
                    st.Push(i);
                }
            }
            /*
            if (v1 != -1)
            {
                List<int> res2 = new List<int>();
                for (int i = 0; i < res.Count - 1; ++i)
                {
                    if (res[i] == v1 && res[i + 1] == v2 || res[i] == v2 && res[i + 1] == v1)
                    {
                        
                        for (int j = i + 1; j < res.Count(); ++j)
                            res2.Add(res[j]);
                        for (int j = 1; j <= i; ++j)
                            res2.Add(res[j]);
                        res = res2;
                        break;
                    }
                }
            }
            */
            for (int i = 0; i < Size; ++i)
                for (int j = 0; j < Size; ++j)
                    if (matrix[i, j] != 0)
                        bad = true;

            if (bad)
                return false;
            else
            {
                for (int i = 0; i < res.Count-1; i++)
                {
                    foreach(Edge edge in EdgesData)
                    {
                        if (edge.From.Index == res[i] && edge.To.Index == res[i+1])
                        {
                            edgesUsed.Add(edge);
                            break;
                        }
                    }
                }
            }
            return true;
        }
    }
}
