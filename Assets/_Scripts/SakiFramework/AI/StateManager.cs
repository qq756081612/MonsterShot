using System;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    public abstract class FSMState
    {
        protected object content;

        public FSMState(object obj)
        {
            content = obj;
        }

        public FSMState(object obj,StateEnum name)
        {
            content = obj;
            stateName = name;
        }

        public T GetContent<T>()
        {
            return (T)content;
        }

        protected Dictionary<TransitionEnum, StateEnum> stateDic = new Dictionary<TransitionEnum, StateEnum>();
        protected StateEnum stateName;
        public StateEnum StateName { get { return stateName; } set { stateName = value; } }

        public void AddTransition(TransitionEnum trans, StateEnum stateName)
        {
            if (trans == TransitionEnum.Null)
            {
                Debug.LogError("FSMState ERROR: NullTransition is not allowed for a real transition");
                return;
            }

            if (stateName == StateEnum.Null)
            {
                Debug.LogError("FSMState ERROR: NullStateID is not allowed for a real ID");
                return;
            }

            if (stateDic.ContainsKey(trans))
            {
                Debug.LogError("FSMState ERROR: State " + this.stateName.ToString() + " already has transition " + trans.ToString() +
                               "Impossible to assign to another state");
                return;
            }

            stateDic.Add(trans, stateName);
        }

        public void RemoveTransition(TransitionEnum trans)
        {
            if (trans == TransitionEnum.Null)
            {
                Debug.LogError("FSMState ERROR: NullTransition is not allowed");
                return;
            }

            if (stateDic.ContainsKey(trans))
            {
                stateDic.Remove(trans);
            }
            else
            {
                Debug.LogError("FSMState ERROR: Transition " + trans.ToString() + " passed to " + stateName.ToString() + " was not on the state's transition list");
            }
        }

        //根据转换条件获取要跳到的下一个状态
        public StateEnum GetOutputState(TransitionEnum trans)
        {
            if (stateDic.ContainsKey(trans))
            {
                return stateDic[trans];
            }
            return StateEnum.Null;
        }

        public virtual void OnEnterState() { }  //进入状态前做的事

        public virtual void OnLeaveState() { }   //离开状态前做的事

        public abstract void Reason(); //状态转换条件

        public abstract void Act();    //当前状态下的行为

    }

    //有限状态机
    public class FSMSystem
    {
        private Dictionary<StateEnum,FSMState> stateDic;

        private StateEnum currentStateEnum;
        public StateEnum CurrentStateEnum { get { return currentStateEnum; } }

        private FSMState currentState;
        public FSMState CurrentState { get { return currentState; } }

        public FSMSystem()
        {
            stateDic = new Dictionary<StateEnum, FSMState>();
        }

        //参数待定 可能会改泛型
        public void Update(SceneObjBase sceneObj)
        {
            currentState.Act();
            currentState.Reason();
        }

        public void AddState(StateEnum stateName , FSMState state)
        {
            if (state == null)
            {
                Debug.LogError("FSM ERROR: Null reference is not allowed");
            }

            if (stateDic.ContainsKey(stateName))
            {
                Debug.LogError("FSM ERROR: Impossible to add state " + stateName.ToString() +
               " because state has already been added");
                return;
            }

            if (stateDic.Count == 0)
            {
                currentState = state;
                currentStateEnum = stateName;
                currentState.OnEnterState();
            }

            stateDic.Add(stateName,state);
        }

        public void RemoveState(StateEnum stateName)
        {
            if (stateName == StateEnum.Null)
            {
                Debug.LogError("FSM ERROR: NullStateID is not allowed for a real state");
                return;
            }

            if (!stateDic.ContainsKey(stateName))
            {
                Debug.LogError("FSM ERROR: Impossible to delete state " + stateName.ToString() +
                           ". It was not on the list of states");
            }

            stateDic.Remove(stateName);
        }

        public void ChangeState(TransitionEnum trans)
        {
            if (trans == TransitionEnum.Null)
            {
                Debug.LogError("FSM ERROR: NullTransition is not allowed for a real transition");
                return;
            }

            StateEnum nextState = currentState.GetOutputState(trans);
            if (nextState == StateEnum.Null)
            {
                Debug.LogError("FSM ERROR: State " + currentStateEnum.ToString() + " does not have a target state " +
                               " for transition " + trans.ToString());
                return;
            }

            currentStateEnum = nextState;

            if (!stateDic.ContainsKey(nextState))
            {
                Debug.LogError("FSM ERROR: State " + currentStateEnum.ToString() + " does not have a target state " +
                               " for transition " + trans.ToString());
                return;
            }

            currentState.OnLeaveState();

            //Debug.LogError("上一个状态已经离开 " + currentState.StateName.ToString());

            currentState = stateDic[nextState];

            //Debug.LogError("下一个状态即将进入 " + currentState.StateName.ToString());

            currentState.OnEnterState();
        }
    }
}
