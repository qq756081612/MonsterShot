﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SakiFramework;
using UnityEngine.UI;

public class SettingView : UIViewBase
{
    private Button continueBtn;
    private Button backBtn;
    private Button closeBtn;

    public override void Initialize()
    {
        continueBtn = GetChild<Button>("continueBtn");
        backBtn = GetChild<Button>("backBtn");
        closeBtn = GetChild<Button>("closeBtn");

        backBtn.onClick.AddListener(OnBackBtnClick);
        closeBtn.onClick.AddListener(OnCloseBtnClick);
        continueBtn.onClick.AddListener(OnCloseBtnClick);
    }

    public void OnCloseBtnClick()
    {
        //关闭页面
        //解除暂停
        UIManager.GetInstance().HideView();
    }

    public void OnBackBtnClick()
    {
        //返回start scene
        LevelManager.GetInstance().LoadScene("Start");
    }

    public override string GetResPath()
    {
        return "SettingView";
    }
}
