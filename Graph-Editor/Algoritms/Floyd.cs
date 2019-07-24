using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Graph_Editor.Globals;

namespace Graph_Editor.Algoritms
{
    public class Floyd : Algoritm
    {
        static int[,] matrix = new int[Size, Size];
        public override void Start()
        {
            MainWindow.Instance.Invalidate();
            floyd();
        }

        static void floyd()
        {
            Array.Copy(Matrix,matrix, Size*Size);
            for (int k = 0; k < Size; k++)
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (matrix[i, k] > 0 && matrix[k, j] > 0)
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + matrix[k, j]);
                    }
                }
            }
        }
    }
}
