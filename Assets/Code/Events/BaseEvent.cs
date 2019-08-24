using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseEvent : ScriptableObject
{
    private HashSet<Action> actions = new HashSet<Action>();

    public void AddListener(Action action)
    {
        if (action == null) return;

        actions.Add(action);
    }

    public void RemoveListener(Action action)
    {
        if (action == null) return;

        actions.Remove(action);
    }

    protected void NotifyListeners()
    {
        actions.ToList().ForEach(action => action.Invoke());
    }
}