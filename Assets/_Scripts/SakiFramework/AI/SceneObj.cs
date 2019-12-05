using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    //所有场景物体的基类
    public abstract class SceneObjBase
    {
        private GameObject gameObject;
        private FSMSystem stateManager;
        private Animator animator;

        public Animator Animator { get => animator; private set => animator = value; }
        public GameObject GameObject { get => gameObject; set => gameObject = value; }
        public FSMSystem StateManager { get => stateManager; set => stateManager = value; }

        public SceneObjBase(GameObject go)
        {
            GameObject = go;
            Animator = go.GetComponent<Animator>();

            StateManager = new FSMSystem();
            InitState();
        }

        protected virtual void InitState()
        {
            //IdleStateBase idleState = new IdleStateBase();

            //stateManager.AddState(StateEnum.Idle,idleState);
        }

        public virtual void Update()
        {
            StateManager.Update(this);
        }
    }

    //public class IdleStateBase : FSMState
    //{
    //    public override void Act()
    //    {
            
    //    }

    //    public override void Reason()
    //    {
            
    //    }
    //}

    //public class MoveStateBase : FSMState
    //{
    //    public override void Act()
    //    {

    //    }

    //    public override void Reason()
    //    {

    //    }
    //}

    //public class BattleStateBase : FSMState
    //{
    //    public override void Act()
    //    {

    //    }

    //    public override void Reason()
    //    {

    //    }
    //}

    //public class DeathStateBase : FSMState
    //{
    //    public override void Act()
    //    {

    //    }

    //    public override void Reason()
    //    {

    //    }
    //}
}


