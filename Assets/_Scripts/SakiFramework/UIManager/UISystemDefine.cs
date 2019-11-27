using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystemDefine
{
    enum UIShowType
    {
        ShowType_Fixed = 1,         //固定窗口 显示在最下层
        ShowType_Normal = 2,        //普通弹出窗口 按弹出先后顺序显示
        ShowType_Top = 3,           //特殊窗口 显示在最顶层
    }
}
