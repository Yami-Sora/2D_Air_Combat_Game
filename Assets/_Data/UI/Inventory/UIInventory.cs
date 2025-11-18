using UnityEngine;

public class UIInventory : YamiMonoBehaviour
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = false;
    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogWarning("Multiple instances of UIInventory detected!");
        UIInventory.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.Close();
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen) this.Open();
        else this.Close();
    }
    public virtual void Open()
    {
        this.gameObject.SetActive(true);
        this.isOpen = true;
    }
    public virtual void Close()
    {
        this.gameObject.SetActive(false);
        this.isOpen = false;
    }
}
