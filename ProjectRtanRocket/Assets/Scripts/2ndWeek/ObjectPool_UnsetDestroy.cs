using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_UnsetDestroy : MonoBehaviour
{
    private List<GameObject> pool;
    private const int minSize = 0;
    private const int maxSize = 100;
    private int curIndex;

    void Awake()
    {
        curIndex = 0;

        pool = new List<GameObject>();
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateObject());
        }
    }

    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        GameObject newObj = new GameObject();
        return newObj;
    }

    public GameObject GetObject()
    {
        // [요구스펙 2] Get Object
        if (curIndex >= pool.Count)
        {
            pool.Add (CreateObject());
        }

        GameObject returnObj = pool[curIndex];
        curIndex++;
        return returnObj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        int targetIdx = pool.FindIndex(idx => ReferenceEquals(obj, idx));

        if (curIndex >= maxSize)
            Destroy(obj);

        else
            pool.Add(obj);

        pool.RemoveAt(targetIdx);
        curIndex--;
    }
}