using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mono的单例类 暂未实现
public class SingertonMono<T> : MonoBehaviour where T : class, new() 
{
    private void Awake()
    {
        instance = new T();
    }

    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    public static T GetInstance()
    {
        return instance;
    }
}
