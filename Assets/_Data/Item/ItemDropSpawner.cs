using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if(ItemDropSpawner.instance != null) Debug.Log("Only one ItemDropSpawner allow!");
        ItemDropSpawner.instance = this;
    }
    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        ItemCode itemcode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemcode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
