using UnityEngine;

public class GameCtrl : YamiMonoBehaviour
{
    private static GameCtrl instance;

    public static GameCtrl Instance { get => instance;}
    [SerializeField] private Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    protected override void Awake()
    {
        base.Awake();
        if(GameCtrl.instance != null) Debug.LogError("Only one GameCtrl allow in scene");
        GameCtrl.instance = this;   
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Camera.main;
        Debug.Log("Main Camera loaded");
    }
}
