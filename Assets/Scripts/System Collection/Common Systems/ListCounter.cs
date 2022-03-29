using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ListCounter<T> : IEnumerable<T>
{
    private List<T> list;

    public T this[int key] => list[key];
    public int Count => list.Count;

    private int currentIndex = -1;


    public ListCounter()
    {
        list = new List<T>();
    }


    public void Add(params T[] items)
    {
        foreach (T item in items)
            if (!list.Contains(item))
                list.Add(item);
    }

    public void Set(params T[] items)
    {
        Clear();

        list.AddRange(items);
    }


    public bool Contains(T item) => list.Contains(item);


    public void Remove(T item)
    {
        if (!list.Contains(item))
            return;

        var index = list.IndexOf(item);

        if (index <= currentIndex)
            currentIndex--;

        list.Remove(item);
    }

    public void Clear()
    {
        list.Clear();
        currentIndex = 0;
    }


    public void Sort() => list.Sort();


    public T GetCurrentItem()
    {
        if (currentIndex < 0)
            currentIndex = 0;

        if (Count <= 0)
            return default(T);

        return list[currentIndex];
    }

    public T GetNextItem()
    {
        currentIndex++;

        if (currentIndex >= Count)
            currentIndex = 0;

        return list[currentIndex];
    }

    public T GetNextItem(Predicate<T> predicate)
    {
        currentIndex++;

        if (currentIndex >= Count)
            currentIndex = 0;

        int NewIndex = list.FindIndex(currentIndex, predicate);

        if (NewIndex > -1)
        {
            currentIndex = NewIndex;
            return list[currentIndex];
        }

        NewIndex = list.FindIndex(0, predicate);


        if (NewIndex > -1)
        {
            currentIndex = NewIndex;
            return list[currentIndex];
        }

        return default(T);
    }


    public void ResetCounter() => currentIndex = -1;


    public T[] ToArray()
    {
        return list.ToArray();
    }


    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)list).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)list).GetEnumerator();
    }
}