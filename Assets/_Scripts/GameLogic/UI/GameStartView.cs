using SakiFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartView : UIViewBase
{
    Button startBtn;

    public override string GetResPath()
    {
        return "GameStartView";
    }

    public override void Initialize()
    {
        startBtn = UIRoot.transform.Find("StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartBtnClick);
    }

    private void OnStartBtnClick()
    {
        Debug.Log("OnStartBtnClick");
    }
}
