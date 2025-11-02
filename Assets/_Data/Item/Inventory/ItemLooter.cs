using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigidbody();
    }
    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning($"ItemLooter: LoadTrigger in {gameObject.name} ", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.LogWarning($"ItemLooter: LoadRigidbody in {gameObject.name} ", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickUpAble itemPickUpAble = other.GetComponent<ItemPickUpAble>();
        if(itemPickUpAble == null) return;

        ItemInventory itemInventory = itemPickUpAble.ItemCtrl.ItemInventory;
        if (this.inventory.AddItem(itemInventory))
        {
            itemPickUpAble.Picked();
        }
    }
}
