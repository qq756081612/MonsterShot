using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    //public abstract class DebugerBase
    //{
    //    public static DebugerBase Instance {get;set;}
    //    public abstract void LogError(string msg);
    //    public abstract void LogWarning(string msg);
    //    public abstract void Log(string msg);
    //}

    //public class DebugerCustom : DebugerBase
    //{
    //    public DebugerCustom()
    //    {
    //        Instance = this;
    //    }

    //    public override void Log(string msg)
    //    {
    //        Debug.Log(msg);
    //    }

    //    public override void LogError(string msg)
    //    {
    //        Debug.LogError(msg);
    //    }

    //    public override void LogWarning(string msg)
    //    {
    //        Debug.LogWarning(msg);
    //    }
    //}

    public class Debuger
    {
        public static void LogError(string msg)
        {
            Debug.LogError(msg);
        }
        public static void LogWarning(string msg)
        {
            Debug.LogWarning(msg);
        }
        public static void Log(string msg)
        {
            Debug.Log(msg);
        }
    }
}


