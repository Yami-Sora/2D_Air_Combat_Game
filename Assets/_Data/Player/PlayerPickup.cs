using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
  public virtual void ItemPickup(ItemPickUpAble itemPickUpAble)
  {
        Debug.Log("ItemPickup");

        ItemInventory itemInventory = itemPickUpAble.ItemCtrl.ItemInventory;
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickUpAble.Picked();
        }
    }
}
