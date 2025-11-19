using UnityEngine;

public class UIInventory : YamiMonoBehaviour
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;
    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogWarning("Multiple instances of UIInventory detected!");
        UIInventory.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        //this.Close();
    }
    protected virtual void FixedUpdate()
    {
        this.ShowItem();
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
    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;
        float itemCount = PlayerCtrl.Instance.CurrentShip.Inventory.Items.Count;
        Debug.Log("ItemCount: "+itemCount);
    }
}
