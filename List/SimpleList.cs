

namespace Codepractice.List
{
    using System;

    public class node
    {
        public object Value { get; set; }

        public node NextNode { get; set; }

        public node PreviousNode { get; set; }

        public node(object val)
        {
            this.Value = val;
            this.NextNode = null;
            this.PreviousNode = null;
        }
    }

    public class ProcessList
    {

        public static node root { get; set; }

        public void AddNode(object value)
        {
            if (root == null)
            {
                root = new node(value);
                return;
            }
            else
            {
                var tempnode = root;
                while (tempnode.NextNode != null)
                {
                    tempnode = tempnode.NextNode;
                }
                tempnode.NextNode = new node(value);
            }
        }

        /// Funtion Defination 
        /// Show all Element in List
        ///Return void
        public void ShowList()
        {
            if (root == null) return;
            var tempnode = root;
            while (tempnode != null)
            {
                Console.WriteLine(
                    $"Number: {tempnode.Value}");
                tempnode = tempnode.NextNode;
            }
        }

        public void Delete(object val)
        {
            if (root == null) return;
            var prevnode = root;
            var currentnode = root;
            while (currentnode != null && (int)currentnode.Value != (int)val)
            {
                prevnode = currentnode;
                currentnode = currentnode.NextNode;
            }
            if (currentnode != null)
            {
                prevnode.NextNode = currentnode.NextNode;
            }
            else
            {
                Console.WriteLine("number to be deleted is not found");
            }
        }

        public node Reverse(node tempnode)
        {
            if (root == null)
                return null;
            if (tempnode.NextNode == null)
            {
                root = tempnode;
                return root;
            }
            else
            {
                return Reverse(tempnode.NextNode).NextNode = tempnode;
            }
        }


    }
}