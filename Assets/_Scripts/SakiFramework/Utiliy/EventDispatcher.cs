using SakiFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    public delegate void EventHandler(params object[] obj);

    public interface IEventDispatcher
    {
        void DispatchEvent(string eventName, params object[] data);
        void AddEventListener(string eventName, EventHandler handler);
        void RemoveEventListener(string eventName, EventHandler handler);
    }

    public class EventDispatcher : Singerton<EventDispatcher>, IEventDispatcher
    {
        //public static EventDispatcher Instance { get; set; }

        //public static EventDispatcher GetInstance()
        //{
        //    return Instance;
        //}

        private Dictionary<string, EventHandler> eventDic = new Dictionary<string, EventHandler>();

        public void AddEventListener(string eventName, EventHandler handler)
        {
            if (eventDic.ContainsKey(eventName))
            {
                eventDic.Add(eventName, _ => { });
            }

            eventDic[eventName] += handler;
        }

        public void DispatchEvent(string eventName, params object[] data)
        {
            if (eventDic.ContainsKey(eventName))
            {
                eventDic[eventName](data);
            }
        }

        public void RemoveEventListener(string eventName, EventHandler handler)
        {
            if (eventDic.ContainsKey(eventName))
            {
                eventDic[eventName] -= handler;
            }
        }
    }
}


