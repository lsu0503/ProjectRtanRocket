using System.Collections.Generic;
using UnityEngine;

public class PoolTest_SetDestroy_ObjectPool : MonoBehaviour
{
    private ObjectPool_SetDestroy_ObjectPool objP;

    [SerializeField] private List<GameObject> Garrage = new List<GameObject>();


    private void Awake()
    {
        objP = GetComponent<ObjectPool_SetDestroy_ObjectPool>();
    }

    public void OnClickRed()
    {
        for (int i = 0; i < 100; i++)
        {
            Garrage.Add(objP.GetObject());
        }
    }

    public void CheckDuplication()
    {
        for (int i = 0; i < Garrage.Count; i++)
        {
            int j = i + 1;

            while (j < Garrage.Count)
            {
                if (ReferenceEquals(Garrage[i], Garrage[j]))
                {
                    Debug.Log("SD_O - 중복 발견!");
                    Garrage.RemoveAt(j);
                }
                else
                    j++;
            }
        }
    }

    public void OnClickBlue()
    {
        CheckDuplication();

        while (Garrage.Count > 0)
        {
            objP.ReleaseObject(Garrage[0]);
            Garrage.RemoveAt(0);
        }
    }
}