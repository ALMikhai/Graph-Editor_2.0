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

            bool[] checkVertex = new bool[Globals.VertexData.Count];

            for(var i = 0; i < Globals.VertexData.Count; ++i)
            {
                checkVertex[i] = false;
            }

            checkVertex[v] = true;

            ThreadAnimation animation = new ThreadAnimation();

            animation.CheckVertex = checkVertex;

            animation.AnimationBypass(v);
        }
    }
}
