using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpart : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.05f;
        Debug.Log("LoadCollider: " + transform.name, gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (_rigidbody != null) return;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        Debug.Log("LoadRigidbody: " + transform.name, gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        this.BulletCtrl.DamageSender.Send(other.gameObject);
    }
}
