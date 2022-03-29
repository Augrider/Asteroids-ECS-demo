using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CacheSystem
{
    /// <summary>
    /// Interface for special dictionary storage classes working with Prefab Cache
    /// </summary>
    /// <typeparam name="T">Type of key to be used</typeparam>
    /// <typeparam name="Z">Type of stored MonoBehaviour component</typeparam>
    public interface IComponentStorage<T, Z> : IEnumerable<Z> where Z : MonoBehaviour
    {
        Z this[T key] { get; }
        int count { get; }


        /// <summary>
        /// Get new component
        /// </summary>
        /// <param name="key">Key assigned to item</param>
        /// <param name="itemName">Optional prefab clone name</param>
        /// <returns>New component added to storage</returns>
        Z GetNewItem(T key, string itemName = "");

        /// <summary>
        /// Clear storage and free all prefabs
        /// </summary>
        void ClearStorage();
    }


    /// <summary>
    /// Interface for special list storage classes working with Prefab Cache
    /// </summary>
    /// <typeparam name="Z">Type of stored MonoBehaviour component</typeparam>
    public interface IComponentStorage<Z> : IEnumerable<Z> where Z : MonoBehaviour
    {
        Z this[int key] { get; }
        int count { get; }


        /// <summary>
        /// Get new component
        /// </summary>
        /// <param name="itemName">Optional prefab clone name</param>
        /// <returns>New component added to storage</returns>
        Z GetNewItem(string itemName = "");

        /// <summary>
        /// Clear storage and free all prefabs
        /// </summary>
        void ClearStorage();
    }
}