using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Group<T>
{
    private HashSet<Action<T>> actions;

    public Group(Action<T> action)
    {
        actions = new HashSet<Action<T>>();
        AddListener(action);
    }

    public void AddListener(Action<T> action) => actions.Add(action);
    public void RemoveListener(Action<T> action) => actions.Remove(action);

    public void NotifyListeners(T value) => actions.ToList().ForEach(action => action.Invoke(value));
}
