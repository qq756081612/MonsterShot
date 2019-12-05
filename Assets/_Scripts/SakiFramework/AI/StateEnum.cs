using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    //状态转换条件
    public enum TransitionEnum
    {
        Null,

        //mainPlayer 玩家控制角色的状态切换条件
        StartControl,                           //玩家开始操作
        StopControl,                            //玩家停止操作
        FindTarget,                             //找到攻击目标
        LoseTarget,                             //丢失攻击目标
        //CanRelive,                              //能够复活
        //ReliveComplete,                         //复活完成

        //Common    通用条件
        HpZero,                                 //Hp为0
        BeAttack,                               //被攻击

    }

    //状态
    public enum StateEnum
    {
        Null,

        Idle,       //空闲
        Move,       //移动
        Attack,     //攻击
        Death,      //死亡
        Hurt,       //受伤
        Relive,     //复活
    }
}
