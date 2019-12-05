using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SakiFramework;

namespace SakiFramework
{
    public class SceneObjManager : Singerton<SceneObjManager>
    {

        private MainPlayer mainPlayer;

        public void Init()
        {

        }

        public void Update()
        {
            if (mainPlayer != null)
            {
                mainPlayer.Update();
            }
        }

        public void InitMainPlayer(GameObject go)
        {
            mainPlayer = new MainPlayer(go);
        }
    }
}


