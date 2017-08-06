using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.Array
{
    public class ConnectedLand
    {
        public int[,] pathMatrix { get; set; }

        public List<Tuple<int,int>> path { get; set; }

        public ConnectedLand(int[,] arr)
        {
            this.pathMatrix = arr;
            this.path = new List<Tuple<int, int>>();
        }

        public int FindPath(int indexa, int indexb, int row, int column)
        {
            if (indexa > row || indexa < 0 || indexb > column || indexb < 0)
                return 0;
            if (indexa == row && indexb == column)
                return 1;
            if (pathMatrix[indexa, indexb] == 0)
                return 0;
            return 1;
        }
    }
}
