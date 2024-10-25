using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool_SetDestroy_ObjectPool : MonoBehaviour
{
    [SerializeField] private ObjectPool<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 300;
    [SerializeField] private int curAll;
    [SerializeField] private int curActive;
    [SerializeField] private int curInactive;

    void Awake()
    {
        curAll = 0;

        pool = new ObjectPool<GameObject>(CreateObject, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, defaultCapacity: minSize, maxSize: maxSize);
    }

    private void Update()
    {
        curAll = pool.CountAll;
        curActive = pool.CountActive;
        curInactive = pool.CountInactive;
    }

    // 풀 내부 요소 생성 함수.
    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        return new GameObject();
    }

    public GameObject GetObject()
    {
        // [요구스펙 2] Get Object
        return pool.Get();
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        pool.Release(obj);
    }

    // 풀에 반환(최대치 이하)될 경우의 동작 [pool에서의 동작이 아님에 주의!]
    void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    // 풀에서 대여 될 경우의 동작 [pool에서의 동작이 아님에 주의!]
    void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    // 풀에 반환(최대치 초과)될 경우의 동작 [pool에서의 동작이 아님에 주의!]
    void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }
}
