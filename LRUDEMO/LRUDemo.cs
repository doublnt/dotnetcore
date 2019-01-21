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

    public class LRUCache<TKey, TValue>
    {
        private int capacity;

        //To-Do Dictionary 非线程安全，需要写 lock
        private readonly Dictionary<TKey, LinkedListNode<LRUCacheItem<TKey, TValue>>> _cacheMap = new Dictionary<TKey, LinkedListNode<LRUCacheItem<TKey,TValue>>>();
        private readonly LinkedList<LRUCacheItem<TKey, TValue>> _lruLinkedList = new LinkedList<LRUCacheItem<TKey,TValue>>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public TValue Get(TKey key)
        {

            if (_cacheMap.ContainsKey(key))
            {
                LinkedListNode<LRUCacheItem<TKey, TValue>> node = _cacheMap[key];

                _lruLinkedList.Remove(node); // O(1) 时间复杂度
                _lruLinkedList.AddFirst(node);
                return node.Value.cacheValue;
            }

            return default(TValue);
        }

        public void AddToFirst(TKey key, TValue value)
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
                    newNode = _lruLinkedList.Last;
                    _lruLinkedList.RemoveLast();

                    _cacheMap.Remove(newNode.Value.cacheKey);
                }
                else
                {
                    LRUCacheItem<TKey, TValue> cacheItem = new LRUCacheItem<TKey, TValue>(key, value);
                    newNode = new LinkedListNode<LRUCacheItem<TKey, TValue>>(cacheItem);
                }

                newNode.Value.cacheValue = value;
                newNode.Value.cacheKey = key;
                _lruLinkedList.AddFirst(newNode);
                _cacheMap.Add(key, newNode);
            }
        }
    }
}