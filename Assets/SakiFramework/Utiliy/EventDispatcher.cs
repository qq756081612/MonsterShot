using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventDispatcher
{
    void DispatchEvent(string eventName,object data);
    void AddEventListener(string eventName,Action<object> handler);
    void RemoveEventListener(string eventName, Action<object> handler);
}

public class EventDispatcher : IEventDispatcher
{
    private Dictionary<string, Action<object>> eventDic = new Dictionary<string, Action<object>>();

    public void AddEventListener(string eventName, Action<object> handler)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic.Add(eventName, _ => {});
        }

        eventDic[eventName] += handler;
    }

    public void DispatchEvent(string eventName,object data)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName](data);
        }
    }

    public void RemoveEventListener(string eventName, Action<object> handler)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] -= handler;
        }
    }
}
