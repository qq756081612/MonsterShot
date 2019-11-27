﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SakiFramework;

//客户端入口 游戏的主循环
public class MainManager : MonoBehaviour
{
    void Awake()
    {
        GameObject.DontDestroyOnLoad(GameObject.Find("Main"));

        //ApplicationFacade.GetInstance().Init();
        //ApplicationFacade.GetInstance().SendNotification(EventName.GameStart,);

        UIManager.GetInstance().Init();
        UIManager.GetInstance().ShowView<GameStartView>("GameStartView");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
