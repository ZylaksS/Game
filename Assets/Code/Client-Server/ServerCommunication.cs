using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ServerCommunication : MonoBehaviour
{
    [Header("Events")] 
    [SerializeField] private SimpleEvent connectToServer;
    [SerializeField] private BoolEventRoot connectionToServerState;

    private void Awake()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        connectToServer.AddListener(TryConnect);
    }

    private void TryConnect()
    {
        if (!NetworkChecker.IsConnectToNetwork())
        {
#if UNITY_EDITOR
            Debug.Log("<color=red>Check the connect to network!</color>", this);
#endif

            return;
        }
        
        connectionToServerState.Invoke(true, "server");
        StartCoroutine(Connecting());
    }

    private IEnumerator Connecting()
    {
        using (var www = UnityWebRequest.Get("http://localhost/Game/index.php"))
        {
            yield return www.SendWebRequest();

            Debug.Log(www.isNetworkError
                ? "<color=red>Network error!</color>"
                : $"<color=green>{www.downloadHandler.text}</color>");

            connectionToServerState.Invoke(false, "server");
        }
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        connectToServer.RemoveListener(TryConnect);
    }
}