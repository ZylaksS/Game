using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button play;
    [SerializeField] private Button exit;

    [Header("Events")] 
    [SerializeField] private SimpleEventRoot connectToServer;

    private void Awake()
    {
        SetListeners();
    }

    private void SetListeners()
    {
        play.onClick.AddListener(ConnectToServer);
        exit.onClick.AddListener(Exit);
    }

    private void ConnectToServer()
    {
        connectToServer.Invoke();
    }

    private void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
