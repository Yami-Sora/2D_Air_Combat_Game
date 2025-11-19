using System;
using UnityEngine;
[Serializable]
public class ItemInventory
{
    [SerializeField] private string itemId = RandomId();
    public string ItemID => itemId;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        // A new ItemInventory will get a new random ID automatically
        ItemInventory item = new ItemInventory
        {
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            maxStack = this.maxStack,
            upgradeLevel = this.upgradeLevel,
        };
        return item;
    }
    public static string RandomId()
    {
        return Guid.NewGuid().ToString();
    }
}