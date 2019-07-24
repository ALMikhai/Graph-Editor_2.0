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

        public override void Start()
        {
            MainWindow.Instance.Invalidate();
            if (hamilton())
                gAnim.NextAnimation(edgesUsed[0], edgesUsed);
        }

        static bool hamilton()
        {

            return true;
        }
    }
}
