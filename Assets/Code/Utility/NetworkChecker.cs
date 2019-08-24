using UnityEngine;

public class NetworkChecker
{
    public static bool IsConnectToNetwork() => Application.internetReachability != NetworkReachability.NotReachable;
}