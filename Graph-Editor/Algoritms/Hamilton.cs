using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Objects;
using static Graph_Editor.Globals;

namespace Graph_Editor.Algoritms
{
    public class Hamilton : Algoritm
    {
        static List<Edge> edgesUsed = new List<Edge>();

        static Queue<int> q = new Queue<int>();
        public override void Start()
        {
            MainWindow.Instance.Invalidate();
            if (hamilton())
                gAnim.NextAnimation(edgesUsed[0], edgesUsed);
        }

        static bool hamilton()
        {
            if (VertexData.Count < 3)
                return false;
            for (int i = 0; i < VertexData.Count; i++)
            {
                int deg = 0;
                for (int j = 0; j < VertexData.Count; j++)
                {
                    if (Matrix[i, j] > 0)
                        deg++;
                }
                if (deg < VertexData.Count / 2)
                    return false;
            }


            for (int i = 0; i < VertexData.Count; i++)
                q.Enqueue(i);
            for (int i = 0; i < 0; i++)
            {

            }

            return true;
        }
    }
}
