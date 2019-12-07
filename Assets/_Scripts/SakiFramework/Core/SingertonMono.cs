using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mono的单例类 暂未实现
public class SingertonMono<T> : MonoBehaviour where T : MonoBehaviour, new() 
{
    private void Awake()
    {
        if (instance != null)
        {
            instance = new T();
        }
        else
        {
            Debug.LogError("场景中已存在单例类：" + typeof(T).ToString());
        }
    }

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Get SingertonMono Faild" + typeof(T).ToString());
            }

            return instance;
        }
    }

    public static T GetInstance()
    {
        return instance;
    }
}
