using System;

namespace Codepractice.List
{
    public class ListMain
    {
        /// <summary>
        /// The process list.
        /// </summary>
        public static void processList()
        {
            ProcessList List = new ProcessList();
            List.AddNode(3);
            List.AddNode(4);
            List.AddNode(5);
            List.AddNode(6);
            List.AddNode(7);
            List.AddNode(8);

            List.ShowList();

            List.Delete(5);

            List.ShowList();

            List.Reverse(ProcessList.root).NextNode = null;

            List.ShowList();

            Console.ReadLine();

        }
    }
}
