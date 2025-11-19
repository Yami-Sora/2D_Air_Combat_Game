using UnityEngine;

public class UIInventoryCtrl : YamiMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => this.content;
    [Header("Inventory Ctrl")]
    [SerializeField] protected UIInvItemSpawner inventorySpawner;
    public UIInvItemSpawner UIInvItemSpawner => inventorySpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadInventorySpawner();
    }
    protected override void Start()
    {
        base.Start();
        for(int i = 0; i < 70; i++)
        {
            this.SpawnTest(i);
        }
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View/Viewport/Content");
        Debug.LogWarning(transform.name + ":LoadContent", gameObject);
    }
    protected virtual void LoadInventorySpawner()
    {
        if (this.inventorySpawner != null) return;
        this.inventorySpawner = GetComponentInChildren<UIInvItemSpawner>(true);
        Debug.LogWarning(transform.name + ":LoadInventorySpawner", gameObject);
    }
    public virtual void SpawnTest(int i)
    {
        Transform uiItem = this.UIInvItemSpawner.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = Vector3.one;
        uiItem.name = "Item_" + i;
        uiItem.gameObject.SetActive(true);
    }
}
