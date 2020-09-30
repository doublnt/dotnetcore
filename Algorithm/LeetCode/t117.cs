/*
// Definition for a Node.
public class Node {
    public int val;
    public Node _left;
    public Node _right;
    public Node _next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node __left, Node __right, Node __next) {
        val = _val;
        _left = __left;
        _right = __right;
        _next = __next;
    }
}
*/
namespace LeetCode
{

    // https://leetcode-cn.com/problems/populating-_next-_right-pointers-in-each-node-ii
    public class t117
    {
        public Node Connect(Node root)
        {
            return Search(root);
        }

        private Node Search(Node root)
        {
            if (root == null)
            {
                return root;
            }

            Node cur = root;

            while (cur != null)
            {
                Node dummy = new Node(0);
                Node pre = dummy;

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

                cur = dummy._next;
            }

            return root;
        }
    }
}
