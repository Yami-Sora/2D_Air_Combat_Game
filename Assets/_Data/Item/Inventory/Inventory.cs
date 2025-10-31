using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : YamiMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.CopperSword, 1);
        this.AddItem(ItemCode.IronOre, 21);
        this.AddItem(ItemCode.GoldOre, 3);
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for(int i=0 ; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null) 
            {
                if (IsInventoryFull()) return false;
                itemExist = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;
            
            itemMaxStack = this.GetMaxStack(itemExist);
            if(newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }
    protected virtual bool IsInventoryFull()
    {
        if(this.items.Count >= this.maxSlot) return true;
        return false;
    }
    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
       var profiles = Resources.LoadAll("Item",typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
            foreach (ItemInventory itemInventory in this.items)
            {
                if (itemCode != itemInventory.itemProfile.itemCode) continue;
                if (this.IsFullStack(itemInventory)) continue;
                return itemInventory;
            }
            return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if(itemInventory == null) return false;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }
    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }
    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory()
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };
        return itemInventory;
    }
    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }
    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }
        return totalCount;
    }
    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;

        for(int i = this.items.Count -1; i >=0 ; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            if(deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }
            itemInventory.itemCount -= deduct;
        }
    }   
}
