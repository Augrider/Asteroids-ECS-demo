using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace CacheSystem
{
    /// <summary>
    /// Library style prefab cache (key is item ID). Use this when you don't need logic connected to type of item, only standard storage operations
    /// </summary>
    /// <typeparam name="T">Class derived from PrefabItem</typeparam>
    public class LibraryCache<T> : ComponentStorage, IComponentStorage<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Dictionary with items, key is item's ID
        /// </summary>
        private Dictionary<int, T> activeItems = new Dictionary<int, T>();

        public T this[int key] => activeItems[key];
        public T[] allItems => activeItems.Values.ToArray();
        public int count => activeItems.Count;


        public LibraryCache(PrefabCache cache) : base(cache) { }


        public T GetNewItem(string itemName = "")
        {
            var result = GetNewFromCache<T>(itemName);
            activeItems.Add(result.gameObject.GetInstanceID(), result);

            return result;
        }


        public bool Contains(int itemID) => activeItems.ContainsKey(itemID);


        public void Remove(int itemID)
        {
            if (activeItems.ContainsKey(itemID))
            {
                SetFree(activeItems[itemID]);
                activeItems.Remove(itemID);
            }
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