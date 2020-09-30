using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Traversal
    {
        public static Node CreateNodeTree()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);

            node1.left = node2;
            node1.right = node3;

            node2.left = node4;
            node2.right = null;

            node3.left = node5;
            node3.right = node6;

            node4.left = node4.right = null;
            node5.left = node5.right = null;
            node6.left = node6.right = null;

            return node1;
        }

        public static void TopTraversal(Node root)
        {
            if (root != null)
            {
                Console.Write(root.val + " ");

                TopTraversal(root.left);
                TopTraversal(root.right);
            }
        }

        public static void BackTraversal(Node root)
        {
            if (root != null)
            {
                BackTraversal(root.left);
                BackTraversal(root.right);

                Console.Write(root.val + " ");
            }
        }

        public static void MiddleTraversal(Node root)
        {
            if (root != null)
            {
                BackTraversal(root.left);
                Console.Write(root.val + " ");
                BackTraversal(root.right);
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
                    if (cur.left != null)
                    {
                        pre.next = cur.left;
                        pre = pre.next;
                    }

                    if (cur.right != null)
                    {
                        pre.next = cur.right;
                        pre = pre.next;
                    }

                    cur = cur.next;
                }

                cur = nextNode.next;
            }

            return root;
        }
    }
}
