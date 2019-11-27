using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SakiFramework;
using UnityEngine.UI;
using System;

public class MainView : UIViewBase
{
    private Button settingBtn;
    public override void Initialize()
    {
        settingBtn = GetChild<Button>("settingBtn");
        settingBtn.onClick.AddListener(OnSettingBtnClick);
    }

    public override string GetResPath()
    {
        return "MainView";
    }

    private void OnSettingBtnClick()
    {
        UIManager.GetInstance().ShowView<SettingView>("SettingView");
    }
}
