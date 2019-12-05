using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SakiFramework;
using UnityEngine;

namespace SakiFramework
{
    public class MainPlayer : SceneObjBase
    {
        private ETCJoystick joystick;

        private bool isControl; //是否被玩家控制
        public bool IsControl { get => isControl; set => isControl = value; }

        private GameObject testAttack;

        public MainPlayer(GameObject go) : base(go)
        {
            joystick = ETCInput.GetControlJoystick("Joystick");

            joystick.onMoveStart.AddListener(OnStartControl);
            joystick.onMoveEnd.AddListener(OnStopControl);

            IsControl = false;

            testAttack = go.transform.Find("TestAttack").gameObject;
        }

        protected override void InitState()
        {
            MainPlayerIdleState idleState = new MainPlayerIdleState(this,StateEnum.Idle);
            MainPlayerMoveState moveState = new MainPlayerMoveState(this, StateEnum.Move);
            MainPlayerDeathState deathState = new MainPlayerDeathState(this, StateEnum.Death);
            MainPlayerAttackState attackState = new MainPlayerAttackState(this, StateEnum.Attack);
            MainPlayerReliveState reliveState = new MainPlayerReliveState(this, StateEnum.Relive);
            MainPlayerHurtState hurtState = new MainPlayerHurtState(this, StateEnum.Hurt);

            //空闲
            idleState.AddTransition(TransitionEnum.StartControl, StateEnum.Move);
            idleState.AddTransition(TransitionEnum.FindTarget, StateEnum.Attack);
            idleState.AddTransition(TransitionEnum.BeAttack, StateEnum.Hurt);
            StateManager.AddState(StateEnum.Idle, idleState);

            //移动
            moveState.AddTransition(TransitionEnum.StopControl, StateEnum.Idle);
            moveState.AddTransition(TransitionEnum.BeAttack, StateEnum.Hurt);
            StateManager.AddState(StateEnum.Move, moveState);

            //攻击
            attackState.AddTransition(TransitionEnum.LoseTarget, StateEnum.Idle);
            attackState.AddTransition(TransitionEnum.StartControl , StateEnum.Move);
            attackState.AddTransition(TransitionEnum.BeAttack, StateEnum.Hurt);
            StateManager.AddState(StateEnum.Attack, attackState);

            //受伤
            hurtState.AddTransition(TransitionEnum.HpZero, StateEnum.Death);
            StateManager.AddState(StateEnum.Hurt, hurtState);

            //死亡
            //deathState.AddTransition(TransitionEnum.CanRelive, StateEnum.Relive);
            StateManager.AddState(StateEnum.Death, deathState);

            //复活
            //reliveState.AddTransition(TransitionEnum.ReliveComplete, StateEnum.Idle);
            //stateManager.AddState(StateEnum.Relive, reliveState);
        }

        public override void Update()
        {
            base.Update();

            //Debug.LogError(StateManager.CurrentStateEnum);
        }

        private void OnStartControl()
        {
            //Debuger.LogError("开始11111111111111");
            IsControl = true;
            Attack(false);
        }

        private void OnStopControl()
        {
            //Debuger.LogError("停止22222222222222222");
            IsControl = false;
        }

        public void Attack(bool enable)
        {
            if (enable)
            {
                Tools.SetLocalPositionY(testAttack, 3.6f);
            }
            else
            {
                Tools.SetLocalPositionY(testAttack, -10);
            }
        }
    }

    public class MainPlayerIdleState : FSMState
    {
        MainPlayer Content;

        public MainPlayerIdleState(MainPlayer obj,StateEnum name) : base(obj,name)
        {
            content = obj;
            Content = GetContent<MainPlayer>();
        }

        public override void OnEnterState()
        {
            //Debuger.Log("OnEnterState:" + TransitionEnum.StopControl.ToString());
            //Content.Animator1.SetBool(TransitionEnum.StopControl.ToString(),true);
            //Content.SetAnimationBool(TransitionEnum.StopControl.ToString(), true);
            Content.Animator1.SetBool(TransitionEnum.StopControl.ToString(), true);
        }

        public override void OnLeaveState()
        {
            Content.Animator1.SetBool(TransitionEnum.StopControl.ToString(), false);
        }

        public override void Reason()
        {
            //Debug.LogError(StateName + "Reason");

            //玩家操作
            if (Content.IsControl)
            {
                Content.StateManager.ChangeState(TransitionEnum.StartControl);
            }

            if (!Content.IsControl && true)
            {
                Content.StateManager.ChangeState(TransitionEnum.FindTarget);
            }
        }

        public override void Act()
        {
            //Debug.LogError(StateName + "Act");
        }
    }

    class MainPlayerMoveState : FSMState
    {
        MainPlayer Content;
        public MainPlayerMoveState(SceneObjBase obj, StateEnum name) : base(obj, name)
        {
            Content = GetContent<MainPlayer>();
        }

        public override void OnEnterState()
        {
            //Debug.LogError(TransitionEnum.StartControl.ToString());
            //Debug.LogError(Content.Animator1);
            Content.Animator1.SetBool(TransitionEnum.StartControl.ToString(), true);
        }

        public override void OnLeaveState()
        {
            Content.Animator1.SetBool(TransitionEnum.StartControl.ToString(), false);
        }

        public override void Reason()
        {
            if (Content.IsControl == false)
            {
                Content.StateManager.ChangeState(TransitionEnum.StopControl);
            }
        }

        public override void Act()
        {
        }
    }

    class MainPlayerAttackState : FSMState
    {
        MainPlayer Content;
        public MainPlayerAttackState(SceneObjBase obj, StateEnum name) : base(obj, name)
        {
            Content = GetContent<MainPlayer>();
        }

        public override void OnEnterState()
        {
            Content.Animator1.SetBool(TransitionEnum.FindTarget.ToString(), true);
        }

        public override void OnLeaveState()
        {
            Content.Animator1.SetBool(TransitionEnum.FindTarget.ToString(), false);
            Content.Attack(false);
        }

        public override void Reason()
        {
            if (Content.IsControl == true)
            {
                Content.StateManager.ChangeState(TransitionEnum.StartControl);
            }
        }

        public override void Act()
        {
            if (Content.Animator1.GetCurrentAnimatorClipInfo(0)[0].clip.name == "FlyFireBreathAttack-Middle")
            {
                Content.Attack(true);
            }
            else
            {
                Content.Attack(false);
            }
        }
    }

    class MainPlayerDeathState : FSMState
    {
        public MainPlayerDeathState(SceneObjBase obj, StateEnum name) : base(obj, name)
        {

        }

        public override void Reason()
        {

        }

        public override void Act()
        {

        }
    }

    class MainPlayerReliveState : FSMState
    {
        public MainPlayerReliveState(SceneObjBase obj, StateEnum name) : base(obj, name)
        {

        }
        public override void Reason()
        {
        }

        public override void Act()
        {
        }
    }

    class MainPlayerHurtState : FSMState
    {
        public MainPlayerHurtState(SceneObjBase obj, StateEnum name) : base(obj, name)
        {

        }
        public override void Reason()
        {
        }

        public override void Act()
        {
        }
    }
}
