using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ServerCommunication : MonoBehaviour
{
    [Header("Events")] 
    [SerializeField] private SimpleEvent connectToServer;

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
        
        StartCoroutine(Connecting());
    }

    private IEnumerator Connecting()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/Game/index.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
#if UNITY_EDITOR
                Debug.Log("<color=red>Network error!</color>");
#endif
                yield break;
            }
            
#if UNITY_EDITOR
            Debug.Log(www.downloadHandler.text);
#endif
        }
    }
}