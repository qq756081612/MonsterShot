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
        IResLoader loader;

        public void Init(ResLoadType type)
        {
            loader = LoaderFactory(type);
        }

        private IResLoader LoaderFactory(ResLoadType type)
        {
            if (type == ResLoadType.LoadByAssetsBundle)
            {
                loader = new ResLoader();
            }
            else
            {
                loader = new ResLoaderAB();
            }

            return loader;
        }

        public T LoadSync<T>(string path) where T : Object
        {
            return loader.LoadSync<T>(path);
        }

        //public T LoadAsyne<T>(string path) where T : Object
        //{
        //    ResourceRequest request = Resources.LoadAsync(path);

        //    if (request.isDone)
        //    {
        //        return (T)request.asset;
        //    }
        //    else
        //    {
        //        Debug.LogError("LoadAsyne failed . Path : " + path);
        //        return null;
        //    }
        //}
    }

    public interface IResLoader
    {
        //不加Object限制会报错
        T  LoadSync<T>(string path) where T : Object;

        //T LoadASync<T>(string path) where T : Object;
    }

    public class ResLoader : IResLoader
    {
        public T LoadSync<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }

    public class ResLoaderAB : IResLoader
    {
        public T LoadSync<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}

