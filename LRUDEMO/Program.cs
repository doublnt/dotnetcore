using System;

namespace LRUDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache<int, int> cache = new LRUCache<int, int>(5);
            cache.AddToFirst(1,1);
            cache.AddToFirst(2,2);
            cache.AddToFirst(3,3);
            cache.AddToFirst(4,4);
            cache.AddToFirst(5,5);

            cache.DisplayList();

            cache.AddToFirst(3,3);
            cache.DisplayList();

            cache.AddToFirst(6,6);
            cache.AddToFirst(7,7);
            cache.DisplayList();
        }
    }
}
