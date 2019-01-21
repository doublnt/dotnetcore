using System;
using System.Collections.Generic;

namespace LRUDemo
{
    class LRUCacheItem<TKey, TValue>
    {

        public TKey cacheKey;
        public TValue cacheValue;
        public LRUCacheItem(TKey cacheKey, TValue cacheValue)
        {
            this.cacheKey = cacheKey;
            this.cacheValue = cacheValue;
        }
    }

    public class LRUDemo<TKey, TValue>
    {
        private int capacity;

        //To-Do Dictionary 非线程安全，需要写 lock
        private readonly Dictionary<TKey, LinkListNode<LRUCacheItem<TKey, TValue>>> _cacheMap = new Dictionary<TKey, LinkListNode<LRUCacheItem>>();
        private readonly LinkedList<LRUCacheItem<TKey, TValue>> _lruLinkedList = new LinkedList<LRUCacheItem>();

        public LRUDemo(int capacity)
        {
            this.capacity = capacity;
        }

        [MethodImp(MethodImpOption.Sychronized)]
        public TValue Get(TKey key)
        {
            LinkedListNode<LRUCacheItem<TKey, TValue>> node;
            if (_cacheMap.TryGetValue(key, out node))
            {
                TValue value = node.Value;
                _lruLinkedList.Remove(node); // O(1) 时间复杂度
                _lruLinkedList.AddFirst(node);
                return value;
            }

            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            if (_cacheMap.ContainsKey(key))
            {
                LinkedListNode<LRUCacheItem<TKey, TValue>> node = _cacheMap[key];
                _lruLinkedList.Remove(node);
                _lruLinkedList.AddFirst(node);

                node.Value.cacheValue = value;
            }
            else
            {
                LinkedListNode<LRUCacheItem<TKey, TValue>> newNode;
                if (_cacheMap.Count >= capacity)
                {
                    newNode = _lruLinkedList.Last();
                    _lruLinkedList.RemoveLast();

                    _cacheMap.Remove(newNode.Value.cacheKey);
                }

                LRUCacheItem<TKey, TValue> cacheItem = new LRUCacheItem<TKey, TValue>(key, value);
                newNode = new LinkedListNode<LRUCacheItemItem<TKey, TValue>>(cacheItem);

                _lruLinkedList.AddFirst(node);
                _cacheMap.Add(key, node);
            }
        }
    }
}