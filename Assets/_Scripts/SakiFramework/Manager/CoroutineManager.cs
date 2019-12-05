using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    //协程的状态
    public enum CoroutineEnum
    {
        Waiting,
        Runing,
        Stop,
        Pause,
    }

    public class CoroutineManager : SingertonMono<CoroutineManager>
    {
        private Dictionary<int, CoroutineController> coroutineDic;

        public void Init()
        {
            coroutineDic = new Dictionary<int, CoroutineController>();
        }

        //返回协程唯一ID供用户控制协程的流程
        public int CoroutineStart(IEnumerator coroutine, bool autoStart = true)
        {
            CoroutineController controll = new CoroutineController(coroutine);

            coroutineDic.Add(controll.ID, controll);

            if (autoStart)
            {
                controll.Start();
            }

            return controll.ID;
        }

        //只执行一次 不缓存
        public void CoroutineStartOnce(IEnumerator coroutine)
        {
            CoroutineController controll = new CoroutineController(coroutine);
            controll.Start();
        }

        public void CoroutineStart(int id)
        {
            if (coroutineDic.ContainsKey(id))
            {
                coroutineDic[id].Start();
            }
            else
            {
                Debug.LogError("Error Coroutine ID : " + id);
            }
        }

        public void CoroutineStop(int id)
        {
            if (coroutineDic.ContainsKey(id))
            {
                coroutineDic[id].Stop();
            }
            else
            {
                Debug.LogError("Error Coroutine ID : " + id);
            }
        }

        public void CoroutinePause(int id)
        {
            if (coroutineDic.ContainsKey(id))
            {
                coroutineDic[id].Pause();
            }
            else
            {
                Debug.LogError("Error Coroutine ID : " + id);
            }
        }

        public void CoroutineResume(int id)
        {
            if (coroutineDic.ContainsKey(id))
            {
                coroutineDic[id].Resume();
            }
            else
            {
                Debug.LogError("Error Coroutine ID : " + id);
            }
        }

        public void CoroutineRestart(int id)
        {
            if (coroutineDic.ContainsKey(id))
            {
                coroutineDic[id].ReStart();
            }
            else
            {
                Debug.LogError("Error Coroutine ID : " + id);
            }
        }
    }


    public class CoroutineController
    {
        private static int id;  //静态自增变量 保证ID的唯一性

        public int ID;
        private CoroutineItem item;
        private IEnumerator enumerator;
        private Coroutine coroutine;

        public CoroutineController(IEnumerator coroutine)
        {
            enumerator = coroutine;
            item = new CoroutineItem();
            GetID();
        }

        public void Start()
        {
            item.State = CoroutineEnum.Runing;
            coroutine = CoroutineManager.GetInstance().StartCoroutine(item.Excute(enumerator));
        }

        public void Pause()
        {
            item.State = CoroutineEnum.Pause;
        }

        public void Stop()
        {
            item.State = CoroutineEnum.Stop;
        }

        public void Resume()
        {
            item.State = CoroutineEnum.Runing;
        }

        public void ReStart()
        {
            if (coroutine != null)
            {
                item.State = CoroutineEnum.Stop;
            }

            Start();
        }

        private void GetID()
        {
            ID = id++;
        }
    }

    public class CoroutineItem
    {
        public CoroutineEnum State;

        //用一个新的迭代器包裹了要执行的迭代器 实现了流程的控制
        public IEnumerator Excute(IEnumerator coroutine)
        {
            if (coroutine == null)
            {
                yield break;
            }

            while (State == CoroutineEnum.Waiting)
            {
                yield return null;
            }

            while (State == CoroutineEnum.Runing)
            {
                if (State == CoroutineEnum.Stop)
                {
                    yield break;
                }

                if (State == CoroutineEnum.Pause)
                {
                    yield return null;
                }
                else
                {
                    if (coroutine.MoveNext())
                    {
                        yield return coroutine.Current;
                    }
                    else
                    {
                        State = CoroutineEnum.Stop;
                    }
                }
            }
        }
    }
}


