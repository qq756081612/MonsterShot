using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SakiFramework;

//客户端入口 游戏的主循环
public class MainManager : MonoBehaviour
{
    private static MainManager instance;

    public static MainManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;

        GameObject.DontDestroyOnLoad(GameObject.Find("Main"));

        //ApplicationFacade.GetInstance().Init();
        //ApplicationFacade.GetInstance().SendNotification(EventName.GameStart,);

        UIManager.GetInstance().Init();
        LevelManager.GetInstance().Init();
        CoroutineManager.GetInstance().Init();
    }

    void Start()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        Debug.Log("Test");

        //while (true)
        //{
        //    Debug.Log("Test");
        //    yield return null;
        //}
        yield return null;
    }

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}
