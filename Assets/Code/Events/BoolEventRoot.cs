using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolEvent : BaseEventParameterized<bool> {}

[CreateAssetMenu(fileName = "Bool Event", menuName = "Events/Bool Event")]
public class BoolEventRoot : BoolEvent
{
    public void Invoke(bool value, string group = "") => NotifyListeners(value, group);
}
