using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObj;

                singletonObj = GameObject.FindObjectOfType(typeof(T)) as GameObject;

                if (singletonObj == null)
                {
                    singletonObj = new GameObject(typeof(T).Name);
                    instance = singletonObj.AddComponent<T>();
                }

                else
                {
                    instance = singletonObj.GetComponent<T>();

                    if(instance == null)
                        instance = singletonObj.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    // AudioManager 작성을 위해 임의 수정.
    protected virtual void Awake()
    {
        // make it as dontdestroyobject
        DontDestroyOnLoad(this.transform.root.gameObject); // 루트 게임 오브젝트를 파괴불능(DonDestroyOnLoad)로 설정한다.
    }
}
