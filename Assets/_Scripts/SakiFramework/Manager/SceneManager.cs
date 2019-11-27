using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SakiFramework;
using UnityEngine.SceneManagement;

namespace SakiFramework
{
    public class LevelManager : Singerton<LevelManager>
    {
        public void LoadScene(string sceneName)
        {
            UIManager.GetInstance().HideAllView();
            if (sceneName == "Main")
            {
                SceneManager.LoadScene("Loading");
                UIManager.GetInstance().ShowView<LoadingView>("LoadingView");


                //SceneManager.LoadScene(sceneName);
                MainManager.GetInstance().StartCoroutine(LoadingSceneAsync(sceneName));
            }
            else if (sceneName == "Loading")
            {

            }
            else if (sceneName == "Battle")
            {
                SceneManager.LoadScene("Loading");

                Scene scene = SceneManager.GetActiveScene();
                Debuger.LogError(scene.name);

                UIManager.GetInstance().ShowView<LoadingView>("LoadingView");

                //SceneManager.LoadScene(sceneName);
                MainManager.GetInstance().StopAllCoroutines();
                MainManager.GetInstance().StartCoroutine(LoadingSceneAsync(sceneName));
            }
        }

        IEnumerator LoadingSceneAsync(string sceneName)
        {
            Scene scene = SceneManager.GetActiveScene();
            Debuger.LogError("222222222222" + scene.name);
            Debuger.LogError("要加载的场景" + sceneName);


            yield return null;

            Debuger.LogError("在这没的？？？？？？？？？？？？？？？？");

            AsyncOperation async;

            async = SceneManager.LoadSceneAsync(sceneName);

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

            //SceneManager.Instance.CurState.OnLeaveScene();

            ///*
            // * 随便写着先的
            // */
            //if (sceneName == "Hall")
            //{
            //    SceneManager.Instance.CurState = new HallState(SceneManager.Instance);
            //}
            //else
            //{
            //    //SceneManager.Instance.CurState = new HallState(SceneManager.Instance);
            //}

            async.allowSceneActivation = true;

            UIManager.GetInstance().HideAllView();

            if (sceneName == "Main")
            {
                UIManager.GetInstance().ShowView<GameStartView>("GameStartView");
            }
            else if (sceneName == "Battle")
            {
                UIManager.GetInstance().ShowView<MainView>("MainView");
            }
            yield return null;


            //SceneManager.Instance.CurState.OnEnterScene();
        }
    }
}


