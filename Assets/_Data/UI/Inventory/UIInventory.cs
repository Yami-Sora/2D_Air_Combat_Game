using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;
    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;
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

    //Tự động cập nhật sắp xếp kho đồ mỗi khi thay đổi giá trị InventorySort
    protected virtual void OnValidate()
    {
        // Chỉ chạy khi game đang ở play mode để tránh lỗi
        if (!Application.isPlaying) return;
        this.ShowItems();
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen) this.Open();
        else this.Close();
    }
    public virtual void Open()
    {
        UIInventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
        this.ShowItems();
    }
    public virtual void Close()
    {
        UIInventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }
    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        // OnValidate có thể gọi hàm này trước khi PlayerCtrl sẵn sàng, gây ra lỗi. Dòng này để ngăn chặn điều đó.
        if (PlayerCtrl.Instance == null || PlayerCtrl.Instance.CurrentShip == null) return;

        this.ClearItems();
        List<ItemInventory> Items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.inventoryCtrl.UIInvItemSpawner;
        foreach (ItemInventory item in Items) 
        {
            spawner.SpawnItem(item);
        }
        this.SortItems();
    }
    protected virtual void ClearItems()
    {
        UIInventoryCtrl.UIInvItemSpawner.ClearItems();
    }
    protected virtual void SortItems()
    {
        switch (this.inventorySort)
        {
            case InventorySort.ByName:
                this.SortByName();
                break;
            case InventorySort.ByCount:
                Debug.Log("InventorySort.ByCount");
                break;
            default:
                Debug.Log("InventorySort.NoSort");
                break;
        }
    }
    protected virtual void SortByName()
    {
        Debug.Log("====InventorySort.ByName====");
        int itemCount = this.inventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;
        bool isSorting = false;
        for (int i = 0; i < itemCount-1; i++)
        {
            currentItem = this.inventoryCtrl.Content.GetChild(i);
            nextItem = this.inventoryCtrl.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfile;
            nextProfile = nextUIItem.ItemInventory.itemProfile;

            currentName = currentProfile.itemName;
            nextName = nextProfile.itemName;


            int compare = string.Compare(currentName, nextName);
            if(compare == 1)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
            Debug.Log(i + ": " + currentName + " | " + nextName + " = " + compare);
        }
        if (isSorting) SortByName();//Đệ quy
    }
    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}
