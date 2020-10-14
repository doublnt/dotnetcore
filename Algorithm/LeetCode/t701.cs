using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class t701
    {
        public Node InsertIntoBST(Node root, int val)
        {
            if (root == null)
            {
                root = new Node(val);

                return root;
            }

            if (val > root.val)
            {
                if (root.right == null)
                {
                    root.right = new Node(val);

                    return root;
                }

                InsertIntoBST(root.right, val);
            }
            else
            {
                if (root.left == null)
                {
                    root.left = new Node(val);

                    return root;
                }

                InsertIntoBST(root.left, val);
            }

            return root;
        }
    }
}
