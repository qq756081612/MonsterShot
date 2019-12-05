using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    public enum ResLoadType
    {
        LoadByResources,
        LoadByAssetsBundle
    }

    //资源管理器
    public class ResManager : Singerton<ResManager>
    {
        private static ResLoadType ResLoadType = ResLoadType.LoadByResources;

        public void Init(ResLoadType type)
        {
            ResLoadType = type;
        }

        public T LoadSync<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public T LoadAsyne<T>(string path) where T : Object
        {
            ResourceRequest request = Resources.LoadAsync(path);

            if (request.isDone)
            {
                return (T)request.asset;
            }
            else
            {
                Debug.LogError("LoadAsyne failed . Path : " + path);
                return null;
            }
        }
    }
}

