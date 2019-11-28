using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    public class UIManager : Singerton<UIManager>
    {
        private Transform root;
        private Transform root_fixed;
        private Transform root_normal;
        private Transform root_pop;

        private Dictionary<string, UIViewBase> uiDic;                       //已经加载到内存中的UI
        private Stack<UIViewBase> uiStack;

        public UIManager()
        {
            root = GameObject.Find("Main/UIRoot/Canvas").transform;
            //root_fixed = root.Find("Fixed");
            root_normal = root.Find("Normal");
            //root_pop = root.Find("Pop");

            uiDic = new Dictionary<string, UIViewBase>();
            uiStack = new Stack<UIViewBase>();
        }

        public void Init()
        {
            //暂时没有需要执行的内容 只是用于调用构造方法
        }

        public void ShowView<T>(string uiName) where T : UIViewBase , new()
        {
            UIViewBase curPanel;
            if (uiDic.ContainsKey(uiName))  //内存中有
            {
                curPanel = uiDic[uiName];
            }
            else                            //内存中没有 需要加载
            {
                if (LoadView<T>(uiName))
                {
                    curPanel = uiDic[uiName];
                }
                else
                {
                    Debuger.LogError("Load ui failed, uiName : " + uiName);
                    return;
                }
            }

            if (uiStack.Count != 0)
            {
                UIViewBase prePanel = uiStack.Peek();
                prePanel.OnDisable();
            }

            uiStack.Push(curPanel);
            curPanel.OnShow();
        }

        public void HideView()
        {
            UIViewBase curPanel = uiStack.Pop();
            curPanel.OnHide();

            if (uiStack.Count > 0)
            {
                UIViewBase prePanel = uiStack.Peek();

                prePanel.OnEnable();
            }
        }

        public void HideAllView()
        {
            //Debuger.LogError("???");

            foreach (var view in uiDic)
            {
                view.Value.OnDestory();
            }

            uiDic.Clear();
            uiStack.Clear();

            //暂时写在这
            //Resources.UnloadUnusedAssets();
            //GC.Collect();
        }

        //临时测试方法 以后应该被消息系统取代
        public UIViewBase GetView(string uiName)
        {
            if (uiDic.ContainsKey(uiName))
            {
                return uiDic[uiName];
            }
            else
            {
                return null;
            }
        }

        private bool LoadView<T>(string uiName) where T : UIViewBase,new()
        {
            //GetResPath

            UIViewBase view = new T();

            const string Path = @"UI/Panel/";
            GameObject uiObject = GameObject.Instantiate(Resources.Load<GameObject>(Path + view.GetResPath()));

            uiObject.SetActive(false);

            //根据类型来设置父物体
            uiObject.transform.SetParent(root_normal.transform, false);

            if (uiObject == null)
            {
                Debug.LogError("InitUI Error : Load uiID failed");
                return false;
            }


            view.SetUIGameObj(uiObject);
            view.Initialize();

            if (uiDic.ContainsKey(uiName) == false)
            {
                uiDic.Add(uiName, view);
            }

            return true;
        }
    }
}
