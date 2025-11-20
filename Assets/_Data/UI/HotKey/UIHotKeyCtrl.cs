using UnityEngine;

public class UIHotKeyCtrl : YamiMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Multiple instances of UIHotKeyCtrl detected!");
        UIHotKeyCtrl.instance = this;
    }
}
