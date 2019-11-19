using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    public interface IUIManager
    {
        //主要功能
        //1.负责UI资源的加载/缓存/卸载
        //2.管理UI及UI特效层级

        //接口
        //1.显示UI
        //2.隐藏UI


        void ShowView(string uiName);                       //显示UI
        void HideView(string uiName);                       //隐藏UI
                                                            //bool LoadView(string uiName);                       //从内存中加载UI
    }


    public class UIManager : IUIManager
    {
        private Dictionary<string, IUIView> uiDic = new Dictionary<string, IUIView>();

        public void ShowView(string uiName)
        {
            if (uiDic.ContainsKey(uiName))
            {
                //缓存中有 直接显示
            }
            else
            {
                //从内存中加载
                if (LoadView(uiName))
                {

                }
                else
                {
                    Debuger.LogError("a");
                }
            }

            throw new System.NotImplementedException();
        }

        public void HideView(string uiName)
        {
            throw new System.NotImplementedException();
        }

        private bool LoadView(string uiName)
        {
            return true;
        }
    }
}
