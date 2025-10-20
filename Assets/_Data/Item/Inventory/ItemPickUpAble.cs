using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUpAble : JunkAbstract
{
    [Header("Item Pick Up Able")]
    [SerializeField] protected SphereCollider _collider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }
    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
        Debug.LogWarning($"ItemPickUpAble: LoadTrigger in {gameObject.name} ", gameObject);
    }
    public virtual ItemCode GetItemCode()
    {
        return ItemPickUpAble.String2ItemCode(transform.parent.name);
    }
    public static ItemCode String2ItemCode(string itemName)
    {
        if (Enum.TryParse<ItemCode>(itemName, true, out var code))
            return code;

        Debug.LogWarning($"Không tìm thấy ItemCode cho: {itemName}");
        return ItemCode.NoItem;
    }
    public virtual void Picked()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}
