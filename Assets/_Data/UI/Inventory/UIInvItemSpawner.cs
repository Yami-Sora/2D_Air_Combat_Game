using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;
    public static string normalItem = "UIInvItem";

    [Header("Inventory Item Spawner")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl InventoryCtrl => inventoryCtrl;

    protected override void LoadComponents()
    {
        this.LoadUIInventoryCtrl();
        base.LoadComponents();
    }
    protected override void Awake()
    {
        base.Awake();
        if (UIInvItemSpawner.instance != null) Debug.LogError("Only 1 UIInventorySpawner allow to exist");
        UIInvItemSpawner.instance = this;
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = GetComponentInParent<UIInventoryCtrl>(true);
        Debug.LogWarning(transform.name + ":LoadUIInventoryCtrl", gameObject);
    }
    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = InventoryCtrl.Content;
        Debug.LogWarning(transform.name + ":LoadHolder", gameObject);
    }
}
