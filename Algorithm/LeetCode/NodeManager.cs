using System;
using System.Xml;

namespace LeetCode
{
    public class NodeManager
    {
        public void main()
        {
            Console.WriteLine("Hello World!");

            var node1 = new Node1(1);
            var node2 = new Node1(2);
            var node3 = new Node1(3);
            var node4 = new Node1(4);
            var node5 = new Node1(5);
            var node6 = new Node1(6);

            node1._left = node2;
            node1._right = node3;

            node2._left = node4;
            node2._right = null;

            node3._left = node5;
            node3._right = node6;

            node4._left = node4._right = null;
            node5._left = node5._right = null;
            node6._left = node6._right = null;

            var node = Connect(node1);

        }

        private static Node1 Connect(Node1 root)
        {
            if (root == null)
            {
                return root;
            }

            Node1 cur = root;

            while (cur != null)
            {
                Node1 nextNode = new Node1(0);

                Node1 pre = nextNode;

                while (cur != null)
                {
                    if (cur._left != null)
                    {
                        pre._next = cur._left;
                        pre = pre._next;
                    }

                    if (cur._right != null)
                    {
                        pre._next = cur._right;
                        pre = pre._next;
                    }

                    cur = cur._next;
                }

                cur = nextNode._next;
            }

            return root;
        }
    }

    public class Node1
    {
        public int _val;
        public Node1 _left;
        public Node1 _right;
        public Node1 _next;

        public Node1(int val)
        {
            _val = val;
        }
    }
}
