using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseEventParameterized<T> : ScriptableObject
{
    private Dictionary<string, Group<T>> actionGroups = new Dictionary<string, Group<T>>();
    private string defaultGroupName = "default";

    public void AddListener(Action<T> action, string groupName = "")
    {
        if (action == null) return;

        if (groupName == string.Empty)
        {
            CreateNewGroup(action, defaultGroupName);
            return;
        }
        
        if (actionGroups.ContainsKey(groupName))
        {
            actionGroups[groupName].AddListener(action);
        }
        else
        {
            CreateNewGroup(action, groupName);
        }
    }

    public void RemoveListener(Action<T> action, string group)
    {
        if (action == null) return;      
        if(!actionGroups.ContainsKey(group)) return;
        
        actionGroups[group].RemoveListener(action);
    }

    protected void NotifyListeners(T value, string group)
    {
        group = group == string.Empty ? defaultGroupName : group;
        
        if(!actionGroups.ContainsKey(group)) return;
        
        actionGroups[group].NotifyListeners(value);
    }

    private void CreateNewGroup(Action<T> action, string groupName) => actionGroups.Add(groupName, new Group<T>(action));
}