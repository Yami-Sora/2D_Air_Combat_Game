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
    protected bool isSortDirty = false;

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

    protected virtual void Update()
    {
        if (this.isSortDirty)
        {
            this.isSortDirty = false;
            this.ShowItems();
        }
    }

    //Tự động cập nhật sắp xếp kho đồ mỗi khi thay đổi giá trị InventorySort
    protected virtual void OnValidate()
    {
        // Chỉ chạy khi game đang ở play mode để tránh lỗi
        if (!Application.isPlaying) return;
        this.isSortDirty = true;
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
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
        if (this.inventorySort == InventorySort.NoSort) return;

        int itemCount = this.inventoryCtrl.Content.childCount;
        bool swappedInPass;

        // Thay thế đệ quy bằng vòng lặp lặp lại để tránh lỗi tràn bộ nhớ stack
        // và cải thiện hiệu suất.
        do
        {
            swappedInPass = false;
            for (int i = 0; i < itemCount - 1; i++)
            {
                Transform currentItem = this.inventoryCtrl.Content.GetChild(i);
                Transform nextItem = this.inventoryCtrl.Content.GetChild(i + 1);

                UIItemInventory currentUIItem = currentItem.GetComponent<UIItemInventory>();
                UIItemInventory nextUIItem = nextItem.GetComponent<UIItemInventory>();

                ItemProfileSO currentProfile = currentUIItem.ItemInventory.itemProfile;
                ItemProfileSO nextProfile = nextUIItem.ItemInventory.itemProfile;

                bool isSwap = false;
                switch (this.inventorySort)
                {
                    case InventorySort.ByName:
                        string currentName = currentProfile.itemName;
                        string nextName = nextProfile.itemName;
                        if (string.Compare(currentName, nextName) == 1) isSwap = true;
                        break;

                    case InventorySort.ByCount:
                        int currentCount = currentUIItem.ItemInventory.itemCount;
                        int nextCount = nextUIItem.ItemInventory.itemCount;
                        // Sắp xếp theo thứ tự giảm dần (số lượng cao nhất trước)
                        if (currentCount < nextCount) isSwap = true;
                        break;
                }

                if (isSwap)
                {
                    this.SwapItems(currentItem, nextItem);
                    swappedInPass = true;
                }
            }
        } while (swappedInPass);
    }
    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}
