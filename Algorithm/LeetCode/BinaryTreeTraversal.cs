using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BinaryTreeTraversal
    {
        public static Node CreateNodeTree()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);

            node1._left = node2;
            node1._right = node3;

            node2._left = node4;
            node2._right = null;

            node3._left = node5;
            node3._right = node6;

            node4._left = node4._right = null;
            node5._left = node5._right = null;
            node6._left = node6._right = null;

            return node1;
        }

        public static void TopTraversal(Node root)
        {
            if (root != null)
            {
                Console.Write(root._val + " ");

                TopTraversal(root._left);
                TopTraversal(root._right);
            }
        }

        public static void BackTraversal(Node root)
        {
            if (root != null)
            {
                BackTraversal(root._left);
                BackTraversal(root._right);

                Console.Write(root._val + " ");
            }
        }

        public static void MiddleTraversal(Node root)
        {
            if (root != null)
            {
                BackTraversal(root._left);
                Console.Write(root._val + " ");
                BackTraversal(root._right);
            }
        }

        public static Node Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }

            Node cur = root;

            while (cur != null)
            {
                Node nextNode = new Node(0);

                Node pre = nextNode;

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
}
