using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    [SerializeField] protected float gameDropRate = 0.01f;
    protected override void Awake()
    {
        base.Awake();
        if(ItemDropSpawner.instance != null) Debug.Log("Only one ItemDropSpawner allow!");
        ItemDropSpawner.instance = this;
    }
    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();

        if (dropList.Count < 1) return null;

        dropItems = this.DropItems(dropList);
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemCode itemcode = itemDropRate.itemProfileSO.itemCode;
            Transform itemDrop = this.Spawn(itemcode.ToString(), pos, rot);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }
        return dropItems;
    }

    protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        foreach (ItemDropRate item in items)
        {
            float rate = Random.Range(0, 100f);
            float itemRate = item.dropRate * this.gameDropRate;
            if (rate <= itemRate)
            {
                droppedItems.Add(item);
            }
        }
        return droppedItems;
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemcode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemcode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);
        return itemDrop;
    }

}
