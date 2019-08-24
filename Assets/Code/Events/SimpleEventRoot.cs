using UnityEngine;

public class SimpleEvent : BaseEvent {}

[CreateAssetMenu(fileName = "Simple Event", menuName = "Events/Simple Event")]
public class SimpleEventRoot : SimpleEvent
{
    public void Invoke() => NotifyListeners();
}