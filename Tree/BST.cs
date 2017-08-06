using System;

namespace BST
{
    public class node
    {
        public int val { get; set; }

        public node Left { get; set; }

        public node Right { get; set; }

        public node(int value)
        {
            this.val = value;
            this.Left = null;
            this.Right = null;
        }
    }


    public class listnode
    {
        public int val { get; set; }
        public listnode next { get; set; }
        public listnode previous { get; set; }

        public listnode(int val)
        {
            this.val = val;
            this.next = null;
            this.previous = null;
        }
    }

    /// <summary>
    /// The tree operation.
    /// </summary>
    public class TreeOperation
    {
        private static node root { get; set; }

        private static node listHead { get; set; }

        private static node currentNode { get; set; }

        private listnode listroot { get; set; }

        static TreeOperation()
        {
            root = null;
            listHead = null;
            int[] a = { 8, 4, 6, 7, 2, 1, 3, 12, 10, 9, 11, 15 };
            foreach (var val in a)
            {
                Addnode(val);
            }
        }

        private static void Addnode(int value)
        {
            if (root == null)
            {
                root = new node(value);
                return;
            }
            var current = root;
            node prev = null;
            while (current != null)
            {
                prev = current;
                if (current.val < value)
                {

                    current = current?.Right;
                }
                else if (current.val > value)
                {
                    current = current?.Left;
                }
                else
                    return;

            }

            if (prev?.val > value)
            {
                prev.Left = new node(value);
            }
            else
                prev.Right = new node(value);
        }


        public void showTree()
        {
            _showTree(root);
        }

        private void _showTree(node x)
        {
            if (x == null)
                return;
            _showTree(x.Left);
            Console.WriteLine(x.val);
            _showTree(x.Right);
        }

        public int GetHeight()
        {
            return _GetHeight(root);
        }

        private int _GetHeight(node x)
        {
            if (x == null)
                return 0;
            return max(_GetHeight(x.Left), _GetHeight(x.Right)) + 1;
        }

        private int max(int a, int b)
        {
            return a > b ? a : b;
        }

        public void printLeftNode()
        {
            this._printLeftNode(root, false);
        }

        private void _printLeftNode(node x, bool Isleft)
        {
            if (x == null)
                return;
            if (Isleft)
            {
                Console.WriteLine(x.val);
            }
            _printLeftNode(x.Left, true);
            _printLeftNode(x.Right, false);
        }


        public void verticalsum()
        {
            this.listroot = new listnode(root.val);

            this._DiagonalSum(root,listroot,2);


        }

        private void _verticalsum(node x, listnode ptr, int Isleft)
        {
            if (x == null) return;
            if (Isleft == 0)
            {
                if (ptr.previous == null)
                {
                    var leftnode = new listnode(x.val);
                    ptr.previous = leftnode;
                    leftnode.next = ptr;
                    _verticalsum(x.Left,leftnode,0);
                    _verticalsum(x.Right, leftnode,1);
                }
                else
                {
                    ptr.previous.val += x.val;
                    _verticalsum(x.Left, ptr.previous, 0);
                    _verticalsum(x.Right, ptr.previous, 1);
                }
            }
            else
            {
                if (ptr.next == null)
                {
                    var rightnode = new listnode(x.val);
                    ptr.next = rightnode;
                    rightnode.previous = ptr;
                    _verticalsum(x.Left, rightnode, 0);
                    _verticalsum(x.Right, rightnode, 1);
                }
                else
                {
                    ptr.next.val += x.val;
                    _verticalsum(x.Left, ptr.next, 0);
                    _verticalsum(x.Right, ptr.next, 1);
                }
            }
        }

        private void _DiagonalSum(node x, listnode ptr, int Isleft)
        {
            if (x == null) return;
            if (Isleft == 0)
            {
                if (ptr.previous == null)
                {
                    var leftnode = new listnode(x.val);
                    ptr.previous = leftnode;
                    leftnode.next = ptr;
                    _DiagonalSum(x.Left, leftnode, 0);
                    _DiagonalSum(x.Right, leftnode, 1);
                }
                else
                {
                    ptr.previous.val += x.val;
                    _DiagonalSum(x.Left, ptr.previous, 0);
                    _DiagonalSum(x.Right, ptr.previous, 1);
                }
            }
            else if (Isleft == 1)
            {
                    ptr.val += x.val;
                   _DiagonalSum(x.Left, ptr, 0);
                   _DiagonalSum(x.Right, ptr, 1);
            }
            else
            {
                _DiagonalSum(x.Left, ptr, 0);
                _DiagonalSum(x.Right, ptr, 1);
            }
        }
        public int findDiameter()
        {
            return _findDiameter(root);
        }

        public int findDepth(node x)
        {
            if (x == null)
                return 0;
            return max(findDepth(x.Left), findDepth(x.Right)) + 1;
        }

        private int _findDiameter(node x)
        {
            if (x == null)
                return 0;
            int l = _findDiameter(x.Left);
            int r = _findDiameter(x.Right);

            int k = findDepth(x.Left) + findDepth(x.Right) + 1;

            return (l + r) > k ? (l + r) : k;
        }

        public void findNode(int val)
        {
            var result = _findnode(root, val);
        }

        private node _findnode(node x,int val)
        {
            if (x == null)
                return null;
            if (x.val == val)
                return x;
            var l =_findnode(x.Left, val);
            var r =  _findnode(x.Right, val);

            if (l != null)
            {
                return x;
            }
            return l ?? r;

        }

        public void FindBSTOrNot()
        {
            bool IsBst = true;
            _findBST(root, false, ref IsBst);
            if (IsBst)
                Console.WriteLine("Trees is BST");
            else
            {
                Console.WriteLine("Tree is not BST");
            }
        }

        private node _findBST(node ptr, bool Isleft, ref bool IsBst)
        {
            if (ptr == null)
            {
                return null;
            }

            var leftnode = _findBST(ptr.Left, true, ref IsBst);
            var rightnode = _findBST(ptr.Right, false, ref IsBst);

            if (Isleft)
            {
                var leftValue = leftnode != null ? leftnode.val : 0;
                var rightvalue = rightnode != null ? rightnode.val : 1000;
                if (leftValue  < ptr.val && ptr.val < rightvalue)
                {
                    
                    return rightnode != null ? rightnode : ptr;
                }
                else
                {
                    IsBst = false;

                }
                 
            }
            else
            {
                var leftValue = leftnode != null ? leftnode.val : 0;
                var rightvalue = rightnode != null ? rightnode.val : 1000;
                if (leftValue < ptr.val && ptr.val < rightvalue)
                {

                    return leftnode != null ? leftnode : ptr;
                }
                else
                {
                    IsBst = false;

                }
            }
            return null;
        }

        public node FindMaxValueInTree()
        {
            return _FindMaxValueInTree(root);
        }

        private node _FindMaxValueInTree(node node)
        {
            if (node == null) return null;
            var l = _FindMaxValueInTree(node.Left);
            var r = _FindMaxValueInTree(node.Right);

            return _findMaxNode(l, r, node);
        }

        private node _findMaxNode(node node, node node1, node node2)
        {
            var maxValue = node2.val;
            var leftValue = node != null ? node.val : 0;
            var rightValue = node1 != null ? node1.val : 0;

            return maxValue > leftValue
                       ? (maxValue > rightValue ? node2 : node1)
                       : leftValue > rightValue ? node : node1;
        }

        public void ConvertTreeToDLL()
        {
            _convertTreeToDll(root);
        }

        private void _convertTreeToDll(node ptr)
        {
            if (ptr == null) return;
            
            _convertTreeToDll(ptr.Left);
            if (listHead == null)
            {
                
                listHead = ptr;
                currentNode = ptr;

            }
            else
            {
                ptr.Left = currentNode;
                currentNode.Right = ptr;
                currentNode = ptr;
            }
            _convertTreeToDll(ptr.Right);
        }

        public void PrintList()
        {
            node tempnode = listHead;
            while (tempnode != null)
            {
                Console.WriteLine(tempnode.val);
                tempnode = tempnode.Right;
            }
        }

        public void SetRootValue(int val)
        {
            root.val = val;
        }
    }
}