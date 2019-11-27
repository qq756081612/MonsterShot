using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public interface IUIView
//{
//    string GetResPath();
//    void OnShow();
//    void OnHide();
//    void OnDestory();
//}

//public class UIViewBase : IUIView
//{
//    public string GetResPath()
//    {
//        throw new System.NotImplementedException();
//    }

//    public void OnDestory()
//    {
//        throw new System.NotImplementedException();
//    }

//    public void OnHide()
//    {
//        throw new System.NotImplementedException();
//    }

//    public void OnShow()
//    {
//        throw new System.NotImplementedException();
//    }
//}

namespace SakiFramework
{
    public abstract class UIViewBase
    {
        private string resPath;             //UI资源路径
        private GameObject uiRoot;           //UI预设      在哪里加载呢？！

        public GameObject UIRoot
        {
            get { return uiRoot; }
        }

        public UIViewBase()
        {
            //resPath = GetResPath();
        }

        public abstract void Initialize();

        public void SetUIGameObj(GameObject gameObj)
        {
            uiRoot = gameObj;
        }

        //获取资源路径 由子类重写
        public abstract string GetResPath();

        #region 生命周期函数

        public virtual void OnShow()
        {
            uiRoot.SetActive(true);
        }
        public virtual void OnHide()
        {
            uiRoot.SetActive(false);
        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {
            //uiObj.SetActive(false);
        }

        public virtual void OnDestory()
        {
            GameObject.Destroy(uiRoot);
        }

        #endregion

        public T GetChild<T>(string path)
        {
            return uiRoot.transform.Find(path).GetComponent<T>();
        }

        public void AddUIEvent()
        {

        }
    }
}


