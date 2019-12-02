//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace SakiFramework
//{
//    public class CoroutineManager : Singerton<CoroutineManager>
//    {
//        private Dictionary<string, Coroutine> coroutineDic;

//        public void Init()
//        {
//            coroutineDic = new Dictionary<string, Coroutine>();
//        }

//        public void CoroutineStart(string coroutineName)
//        {
//            //coroutineDic.Add()
//        }

//        public void CoroutineStop(string coroutineName)
//        {
//            if (coroutineDic.ContainsKey(coroutineName))
//            {
//                //coroutineDic[coroutineName].Stop();
//                coroutineDic.Remove(coroutineName);
//            } 
//        }

//        public void CoroutinePause(string coroutineName)
//        {
//            if (coroutineDic.ContainsKey(coroutineName))
//            {
//                //coroutineDic[coroutineName].Pause();
//            }
//        }

//        public void CoroutineResume(string coroutineName)
//        {
//            if (coroutineDic.ContainsKey(coroutineName))
//            {
//                //coroutineDic[coroutineName].Resume();
//            }
//        }
//    }


//}


