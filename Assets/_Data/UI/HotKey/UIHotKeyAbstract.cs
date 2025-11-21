using UnityEngine;

public abstract class UIHotKeyAbstract : YamiMonoBehaviour
{
    [SerializeField] private UIHotKeyCtrl hotKeyCtrl;
    protected UIHotKeyCtrl HotKeyCtrl  => hotKeyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKeyCtrl();
    }
    protected virtual void LoadUIHotKeyCtrl()
    {
        if (hotKeyCtrl != null) return;
        this.hotKeyCtrl = GetComponentInParent<UIHotKeyCtrl>();
        Debug.LogWarning(transform.parent + ": LoadUIHotKeyCtrl", gameObject);
    }
}
