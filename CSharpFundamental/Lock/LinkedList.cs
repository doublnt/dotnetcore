using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    internal class Node
    {
        internal Node m_next;
    }

    internal class LinkedList
    {
        private Node m_head;

        public void Add(Node node)
        {
            node.m_next = m_head;
            m_head = node;
        }
    }
}
