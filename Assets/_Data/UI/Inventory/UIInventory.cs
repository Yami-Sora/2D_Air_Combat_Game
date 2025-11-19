using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
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
    //protected virtual void FixedUpdate()
    //{
    //    this.ShowItem();
    //}
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
        this.ShowItem();
    }
    public virtual void Close()
    {
        UIInventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }
    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;
        this.ClearItems();
        List<ItemInventory> Items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.inventoryCtrl.UIInvItemSpawner;
        foreach (ItemInventory item in Items) 
        {
            spawner.SpawnItem(item);
        }

    }
    protected virtual void ClearItems()
    {
        UIInventoryCtrl.UIInvItemSpawner.ClearItems();
    }
}
