using UnityEngine;

public class LoadCircle : MonoBehaviour
{
    [Header("UI Elements")] 
    [SerializeField] private GameObject loadingWindow;

    [Header("Events")] 
    [SerializeField] private BoolEvent onLoadingWindow;

    private void Awake()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        onLoadingWindow.AddListener(ChangeLoadingWindow, "server");
    }

    private void ChangeLoadingWindow(bool state)
    {
        loadingWindow.SetActive(state);
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        onLoadingWindow.RemoveListener(ChangeLoadingWindow, "server");
    }
}
