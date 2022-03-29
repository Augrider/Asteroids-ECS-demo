using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CacheSystem
{
    internal class PrefabItem
    {
        public bool inUse { get; private set; }
        public GameObject cloneObject { get; private set; }

        /// <summary>
        /// Get InstanceID of item in storage
        /// </summary>
        public int itemID => cloneObject.GetInstanceID();


        public PrefabItem(GameObject prefab)
        {
            this.cloneObject = prefab;
            this.inUse = false;

            ToggleInUse(false);
        }


        public void ToggleInUse(bool value)
        {
            inUse = value;
            cloneObject.SetActive(value);
        }


        public override string ToString()
        {
            return string.Format("Prefab {0}, in use {1}", cloneObject, inUse);
        }
    }
}