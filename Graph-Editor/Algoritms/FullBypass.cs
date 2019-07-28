using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Graph_Editor.Algoritms
{
    class FullBypass : Algoritm
    {
        public override void Start(int v)
        {
            MainWindow.Instance.Invalidate();

            ThreadAnimation animation = new ThreadAnimation();

            animation.SetAndStartDijkstra(v);
        }
    }
}
