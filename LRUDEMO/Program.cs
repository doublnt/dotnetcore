using System;

namespace LRUDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache<int, int> cache = new LRUCache<int, int>(5);
        }
    }
}
