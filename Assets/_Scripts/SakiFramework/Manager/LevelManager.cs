using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SakiFramework;
using UnityEngine.SceneManagement;

namespace SakiFramework
{
    public class LevelManager : Singerton<LevelManager>
    {
        public void Init()
        {
            SceneManager.activeSceneChanged += ChangeSceneHandler;
            SceneManager.LoadScene("Start");
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene("Loading");
            MainManager.GetInstance().StartCoroutine(LoadingSceneAsync(sceneName));
        }

        public void ChangeSceneHandler(Scene curScene,Scene nextScene)
        {            
            UIManager.GetInstance().HideAllView();

            if (nextScene.name == "Start")
            {
                UIManager.GetInstance().ShowView<GameStartView>("GameStartView");
            }
            else if (nextScene.name == "Battle")
            {
                UIManager.GetInstance().ShowView<MainView>("MainView");
                BattleSceneTest();
            }
            else if (nextScene.name == "Loading")
            {
                UIManager.GetInstance().ShowView<LoadingView>("LoadingView");
            }
        }

        public void BattleSceneTest()
        {
            //根据配置生成怪物 主角模型
            //GameObject player = ResManager.GetInstance().LoadSync<GameObject>("Model/Player/Player_001");
            //GameObject.Instantiate(player);

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            SceneObjManager.GetInstance().InitMainPlayer(player);
        }

        IEnumerator LoadingSceneAsync(string sceneName)
        {
            yield return null;

            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

            async.allowSceneActivation = false;

            LoadingView view = (LoadingView)UIManager.GetInstance().GetView("LoadingView");

            float displayProgress = 0;
            float realProgress = 0;

            while (async.progress < 0.9f)
            {
                realProgress = async.progress;

                while (displayProgress < realProgress)
                {
                    displayProgress += 0.01f;
                    view.UpdataProgress(displayProgress);
                    yield return null;
                }
            }

            realProgress = 1;

            while (displayProgress < realProgress)
            {
                displayProgress += 0.01f;
                view.UpdataProgress(displayProgress);
                yield return null;
            }

            async.allowSceneActivation = true;
        }
    }
}


