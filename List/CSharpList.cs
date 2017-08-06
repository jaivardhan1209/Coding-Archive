using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.List
{
    public class CSharpList
    {
        public List<int> intList { get; set; }

        public CSharpList()
        {
            this.intList = new List<int>();
        }

        public void PopulateList()
        {
            for(int i = 0; i <= 9; i++)
            {
                this.intList.Add(i);
            }
        }

        public void showList()
        {
            foreach(var element in this.intList)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
