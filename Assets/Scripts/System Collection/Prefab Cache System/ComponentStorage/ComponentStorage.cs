using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CacheSystem
{
    /// <summary>
    /// Base class for all component storage using PrefabCacheHandler system
    /// </summary>
    public abstract class ComponentStorage
    {
        private PrefabCache cache;


        public ComponentStorage(PrefabCache cache)
        {
            this.cache = cache;

            OnInit(cache);
        }


        protected T GetNewFromCache<T>(string itemName = "") where T : MonoBehaviour
        {
            var newGameObject = cache.GetNew(itemName);

            if (newGameObject.TryGetComponent<T>(out var component))
                return component;

            throw new NullReferenceException("No component of provided type was found!");
        }

        protected void SetFree(MonoBehaviour behaviour)
        {
            cache.SetFree(behaviour.gameObject.GetInstanceID());
        }



        /// <summary>
        /// Clear storage and free all prefabs
        /// </summary>
        public abstract void ClearStorage();

        protected virtual void OnInit(PrefabCache cache) { }
    }
}