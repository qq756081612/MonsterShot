using UnityEngine;
using System.Collections;

namespace SakiFramework
{
    //单例的基类
    public class Singerton<T> where T : class, new()
    {
        private static readonly object syncRoot = new object();

        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new T();

                            if (instance is MonoBehaviour)
                            {
                                Debug.LogError("MonoBehaviour 要继承SingertonMono实现单例");
                                return null;
                            }
                        }
                    }
                }
                return instance;
            }
        }

        public static T GetInstance()
        {
            return Instance;
        }
    }
}


