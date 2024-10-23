using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_SetRecycle : MonoBehaviour
{
    private List<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 300;
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
        GameObject returnObj;

        if (curIndex < pool.Count)
        {
            returnObj = pool[curIndex];
            curIndex++;
        }

        else
        {
            returnObj = pool[0];
            pool.RemoveAt(0);
            pool.Add(returnObj);
        }
        
        return returnObj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        int targetIdx = pool.FindIndex(idx => ReferenceEquals(obj, idx));
        
        pool.Add(obj);
        pool.RemoveAt(targetIdx);
        curIndex--;
    }
}