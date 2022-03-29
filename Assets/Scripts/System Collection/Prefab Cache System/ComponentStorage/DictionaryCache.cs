using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace CacheSystem
{
    /// <summary>
    /// Dictionary style prefab cache (key defined by user). Use this when you don't need logic connected to type of item, only standard storage operations
    /// </summary>
    /// <typeparam name="T">Keys used for getting stored prefab classes</typeparam>
    /// <typeparam name="Z">Class derived from PrefabItem</typeparam>
    public class DictionaryCache<T, Z> : ComponentStorage, IComponentStorage<T, Z> where Z : MonoBehaviour
    {
        private Dictionary<T, Z> activeItems = new Dictionary<T, Z>();

        public Z this[T key] => activeItems[key];
        public Z[] allItems => activeItems.Values.ToArray();
        public int count => activeItems.Count;


        public DictionaryCache(PrefabCache cache) : base(cache) { }


        public Z GetNewItem(T key, string itemName = "")
        {
            if (activeItems.ContainsKey(key))
            {
                Debug.LogError("Tried to get new item, but item with the same key exists! Returning recorded");
                return activeItems[key];
            }

            var result = GetNewFromCache<Z>(itemName);

            activeItems.Add(key, result);
            return result;
        }


        public bool TryGetItem(T key, out Z result)
        {
            result = ContainsKey(key) ? activeItems[key] : null;

            return result;
        }


        public bool ContainsKey(T key) => activeItems.ContainsKey(key);


        public void Remove(T key)
        {
            if (activeItems.ContainsKey(key))
            {
                SetFree(activeItems[key]);
                activeItems.Remove(key);
            }
        }

        public override void ClearStorage() => activeItems.Clear();


        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)activeItems).GetEnumerator();
        }

        IEnumerator<Z> IEnumerable<Z>.GetEnumerator()
        {
            return ((IEnumerable<Z>)(activeItems.Values)).GetEnumerator();
        }
    }
}