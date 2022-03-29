using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CacheSystem
{
    /// <summary>
    /// List style prefab cache. Use this when you don't need logic connected to type of item, only standard storage operations
    /// </summary>
    /// <typeparam name="T">Class derived from PrefabItem</typeparam>
    public class ListCache<T> : ComponentStorage, IComponentStorage<T> where T : MonoBehaviour
    {
        private List<T> activeItems = new List<T>();

        public T this[int key] => activeItems[key];
        public int count => activeItems.Count;


        public ListCache(PrefabCache cache) : base(cache) { }


        public T GetNewItem(string itemName = "")
        {
            var result = GetNewFromCache<T>(itemName);
            activeItems.Add(result);

            return result;
        }


        public override void ClearStorage() => activeItems.Clear();


        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)activeItems).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)activeItems).GetEnumerator();
        }
    }
}