using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : YamiMonoBehaviour
{
    public JunkCtrl junkCtrl;
    public int dropCount = 0;
    //Danh sách item đã rớt và số lượng
    public List<ItemDropCount> itemDropCounts = new List<ItemDropCount>();

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Droping), 2f, 0.5f);
    }
    protected virtual void Droping()
    {
        dropCount += 1;
        Vector3 dropPos = transform.position;
        Quaternion dropPot = transform.rotation;
        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropPot);

        //Cập nhật số lượng rớt của từng item
        ItemDropCount itemDropCount;
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            //Tìm item trong danh sách đã rớt. Với mỗi phần tử i trong itemDropCounts, hàm trả về true nếu i.itemName bằng itemDropRate.itemProfileSO.itemName.
            itemDropCount = this.itemDropCounts.Find(i => i.itemName == itemDropRate.itemProfileSO.itemName);
            if(itemDropCount == null)
            {
                itemDropCount = new ItemDropCount();
                itemDropCount.itemName = itemDropRate.itemProfileSO.itemName;
                this.itemDropCounts.Add(itemDropCount);
            }
            itemDropCount.count += 1;
            itemDropCount.rate = (float)Math.Round((float)itemDropCount.count / dropCount,2);
        }
    }
    [Serializable]
    public class ItemDropCount
    {
        public string itemName;
        public int count;
        public float rate;
    }
}
