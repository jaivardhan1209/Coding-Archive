using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.Graph
{
    public class Dfs
    {
        public int[,] adjMatrix { get; set; }

        public Dfs(int[,] abc)
        {
            this.adjMatrix = abc;
        }

        public void showAdjMatrx()
        {
            for (int i = 0; i <= adjMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= adjMatrix.GetUpperBound(1); j++)
                {
                    Console.Write(adjMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool Perform_Dfs(int x)
        {
            var arr = new int[7];
            for (int j = 0; j <= adjMatrix.GetUpperBound(1); j++)
            {
                if (adjMatrix[x, j] == 1)
                {

                    Console.Write($"{x},{j}\n");
                    if (arr[x] == 1)
                    {
                        return true;
                    }
                    arr[x] = 1;
                    adjMatrix[x, j] = 0;
                    Perform_Dfs(j);
                }
            }
            return false;
        }

        public void CheckCycleExist()
        {
            if (Perform_Dfs(1))
                Console.WriteLine("cycle exists");
            else
                Console.WriteLine("Dycle doesn't exists");

        }

    }
}

