using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ScriptableObjectsSystem.Sets;

namespace CacheSystem
{
    /// <summary>
    /// Cache storage component for prefabs
    /// </summary>
    public sealed class PrefabCache : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        [SerializeField] private Transform parent;
        private Transform correctParent => parent ? parent : transform;

        [Tooltip("Optional GameObjectRuntimeSet for recording prefab instances in use")]
        [SerializeField] private GameObjectRuntimeSet gameObjectSet;

        /// <summary>
        /// Amount of copies loaded at the start of the game
        /// </summary>
        [SerializeField] private int preloadAmount = 0;

        /// <summary>
        /// Dictionary of all instantiated prefab items
        /// </summary>
        private Dictionary<int, PrefabItem> allCached = new Dictionary<int, PrefabItem>();
        public GameObject last => allCached.Values.Last().cloneObject;


        // Start is called before the first frame update
        void Start()
        {
            Preload(preloadAmount);
        }

        /// <summary>
        /// Load an amount of unused items
        /// </summary>
        /// <param name="amount">Amount of items</param>
        public void Preload(int amount = 1)
        {
            if (amount <= 0)
                return;

            for (int i = 0; i < amount; i++)
                CreateNew();

            FreeAll();
        }


        /// <summary>
        /// Get new or available prefab gameObject
        /// </summary>
        /// <param name="itemName">Optional name for object</param>
        public GameObject GetNew(string itemName = "")
        {
            var newPrefabItem = GetNewItem();

            SetName(newPrefabItem, itemName);
            newPrefabItem.ToggleInUse(true);

            gameObjectSet?.Add(newPrefabItem.cloneObject);

            return newPrefabItem.cloneObject;
        }


        /// <summary>
        /// Check if prefab is currently in use
        /// </summary>
        /// <param name="instanceID">GameObject Instance ID</param>
        /// <returns>true if prefab with the same ID found and in use</returns>
        public bool ContainsInUse(int instanceID)
        {
            return allCached.ContainsKey(instanceID) ? allCached[instanceID].inUse : false;
        }


        /// <summary>
        /// Free prefab from use
        /// </summary>
        /// <param name="instanceID">GameObject Instance ID</param>
        public void SetFree(int instanceID)
        {
            if (allCached.ContainsKey(instanceID) && allCached[instanceID].inUse)
                FreeItem(allCached[instanceID]);
        }

        /// <summary>
        /// Free all prefabs from use
        /// </summary>
        public void FreeAll()
        {
            foreach (PrefabItem item in allCached.Values)
                FreeItem(item);
        }



        private PrefabItem GetNewItem()
        {
            if (GetFirstPassive(out var result))
                return result;

            return CreateNew();
        }

        private PrefabItem CreateNew()
        {
            var newObject = Instantiate(prefab, correctParent);

            var objectItem = new PrefabItem(newObject);
            allCached.Add(newObject.GetInstanceID(), objectItem);

            return objectItem;
        }

        private bool GetFirstPassive(out PrefabItem result)
        {
            result = allCached.Values.FirstOrDefault(t => !t.inUse);
            return result != null;
        }


        private void SetName(PrefabItem item, string name = "")
        {
            if (!string.IsNullOrEmpty(name))
                item.cloneObject.name = name;
        }


        private void FreeItem(PrefabItem item)
        {
            item.ToggleInUse(false);
            gameObjectSet?.Remove(item.cloneObject);
        }
    }
}