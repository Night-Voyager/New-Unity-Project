using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Dictionary<string, List<Delegate>> events = new Dictionary<string, List<Delegate>>();

    public static void AddEvent<T>(string eventName, Action<T> callback)
    {
        List<Delegate> actions = null;

        if (events.TryGetValue(eventName, out actions))
        {
            actions.Add(callback);
        }
        else
        {
            actions = new List<Delegate>();
            actions.Add(callback);
            events.Add(eventName, actions);
        }
    }

    public static void AddEvent(string eventName, Action callback)
    {
        List<Delegate> actions = null;

        if (events.TryGetValue(eventName, out actions))
        {
            actions.Add(callback);
        }
        else
        {
            actions = new List<Delegate>();
            actions.Add(callback);
            events.Add(eventName, actions);
        }
    }

    public static void RemoveEvent<T>(string eventName, Action<T> callback)
    {
        List<Delegate> actions = null;

        if (events.TryGetValue(eventName, out actions))
        {
            actions.Remove(callback);
            if (actions.Count == 0)
            {
                events.Remove(eventName);
            }
        }
    }

    public static void RemoveAllEvents()
    {
        events.Clear();
    }

    public static void DispatchEvent<T>(string eventName, T arg)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);
            foreach(var action in actions)
            {
                action.DynamicInvoke(arg);
            }
        }
    }

    public static void DispatchEvent(string eventName)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);
            foreach(var action in actions)
            {
                action.DynamicInvoke();
            }
        }
    }
}
