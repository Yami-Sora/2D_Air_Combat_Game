using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;
    public static string normalItem = "UIInvItem";

    [Header("Inventory Item Spawner")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

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
        this.holder = UIInventoryCtrl.Content;
        Debug.LogWarning(transform.name + ":LoadHolder", gameObject);
    }
    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawn(item);
        }
    }
    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.UIInventoryCtrl.UIInvItemSpawner.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = Vector3.one;

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);
        uiItem.gameObject.SetActive(true);
    }
}
