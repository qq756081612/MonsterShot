using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace zFrame.Extend
{
    public static class CoroutineEx
    {
        public static CoroutineHandler Start(this IEnumerator enumerator)
        {
            CoroutineHandler handler = new CoroutineHandler(enumerator);
            handler.Start();
            return handler;
        }
    }
    public class CoroutineHandler
    {
        public IEnumerator Coroutine { get; private set; } = null;
        public bool Paused { get; private set; } = false;
        public bool Running { get; private set; } = false;
        public bool Stopped { get; private set; } = false;
        public class FinishedHandler : UnityEngine.Events.UnityEvent<bool> { }
        public FinishedHandler OnCompleted = new FinishedHandler();
        public CoroutineHandler(IEnumerator c)
        {
            Coroutine = c;
        }

        public void Pause()
        {
            Paused = true;
        }

        public void Resume()
        {
            Paused = false;
        }

        public void Start()
        {
            if (null != Coroutine)
            {
                Running = true;
                CoroutineDriver.Run(CallWrapper());
            }
            else
            {
                Debug.Log("Coroutine 未指定，避免直接调用该方法。");
            }
        }

        public void Stop()
        {
            Stopped = true;
            Running = false;
        }

        /// <summary>
        /// 完成回调并断引用
        /// </summary>
        private void Finish()
        {
            OnCompleted?.Invoke(Stopped);
            this.OnCompleted.RemoveAllListeners();
            this.Coroutine = null;
        }
        /// <summary>
        /// 添加协程执行完成事件
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public CoroutineHandler OnComplete(UnityAction<bool> action)
        {
            this.OnCompleted.AddListener(action);
            return this;
        }

        #region IEnumerator Wrapper
        IEnumerator CallWrapper()
        {
            yield return null;
            IEnumerator e = Coroutine;
            while (Running)
            {
                if (Paused)
                    yield return null;
                else
                {
                    if (e != null && e.MoveNext())
                    {
                        yield return e.Current;
                    }
                    else
                    {
                        Running = false;
                    }
                }
            }
            Finish();
        }
        #endregion

        internal class CoroutineDriver : MonoBehaviour
        {
            static CoroutineDriver driver;
            static CoroutineDriver Driver
            {
                get
                {
                    if (null == driver)
                    {
                        GameObject go = new GameObject("[CoroutineDriver]");
                        driver = go.AddComponent<CoroutineDriver>();
                        GameObject.DontDestroyOnLoad(go);
                        go.hideFlags = HideFlags.HideAndDontSave;
                    }
                    return driver;
                }
            }
            private void Awake()
            {
                if (null != driver && driver != this) //避免了跳场景导致的重复生成问题
                {
                    GameObject.Destroy(gameObject);
                }
            }
            public static Coroutine Run(IEnumerator target)
            {
                return Driver.StartCoroutine(target);
            }
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using zFrame.Extend;

//public class TestCorountineEx : MonoBehaviour
//{
//    CoroutineHandler task;
//    bool finish = false;

//    public void StartTask()
//    {
//        if (null == task || !task.Running)
//        {
//            finish = false;
//            Debug.Log("协程开始");
//            task = MyAwesomeTask().Start();
//            task.OnCompleted.AddListener(v => //第一种事件注册方式
//            {
//                if (v)
//                {
//                    Debug.Log("操作完成：用户取消了操作！");
//                }
//                else
//                {
//                    Debug.Log("操作完成！");
//                }
//            });
//            task.OnComplete(v => Debug.Log("喵呜~ ---" + v)); //第二种事件注册方式（链式）
//        }
//        else
//        {
//            Debug.Log("不需要启动的Task");
//        }
//    }

//    private void OnGUI()
//    {
//        if (GUILayout.Button("启动协程"))
//        {
//            StartTask();
//        }

//        if (null == task || !task.Running) return;
//        if (GUILayout.Button("强制停止"))
//        {
//            Debug.Log("强制停止");
//            task.Stop();
//        }
//        if (GUILayout.Button("完成协程"))
//        {
//            Debug.Log("模拟协程完成操作");
//            finish = true;
//            if (task.Paused)
//            {
//                Debug.Log("模拟协程完成操作--事件在恢复Task时发出~");
//            }
//        }

//        if (GUILayout.Button(task.Paused ? "继续" : "暂停"))
//        {
//            if (task.Paused)
//            {
//                Debug.Log("继续");
//                task.Resume();
//            }
//            else
//            {
//                Debug.Log("暂停");
//                task.Pause();
//            }
//        }

//    }

//    IEnumerator MyAwesomeTask()
//    {
//        while (!finish)
//        {
//            Debug.Log("运行中...");
//            yield return null;
//        }
//    }
//}

