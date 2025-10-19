using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUpAble : YamiMonoBehaviour
{
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
    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("Picked up: " + other.name);
        transform.parent.gameObject.SetActive(false);
    }
}
