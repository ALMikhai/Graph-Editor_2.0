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
            Array.Copy(Matrix, matrix, Size * Size);
            for (int i = 0; i < VertexData.Count; i++)
            {
                for (int j = 0; j < VertexData.Count; j++)
                {
                    if(i != j && matrix[i,j] == 0)
                    {
                        matrix[i, j] = 10000001;
                    }
                }
            }
            floyd();
        }

        static void floyd()
        {
            
            for (int k = 0; k < VertexData.Count; k++)
            {
                for (int i = 0; i < VertexData.Count; i++)
                {
                    for (int j = 0; j < VertexData.Count; j++)
                    {
                        if (matrix[i, k] < 10000001 && matrix[k, j] < 10000001)
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + matrix[k, j]);
                    }
                }
            }

        }
    }
}
