using SakiFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : UIViewBase
{
    private Image processImg;

    public override string GetResPath()
    {
        return "LoadingView";
    }

    public override void Initialize()
    {
        processImg = UIRoot.transform.Find("Content").GetComponent<Image>();
    }
}
