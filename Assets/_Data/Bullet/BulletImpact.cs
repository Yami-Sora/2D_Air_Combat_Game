using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
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
        //Debug.Log(other.transform.parent.name);
        //Debug.Log(transform.parent.name);
        //if (other.transform.parent == this.BulletCtrl.Shooter) return;
        this.BulletCtrl.DamageSender.Send(other.gameObject);
        //this.CreateImpactFX();
    }
    //protected virtual void CreateImpactFX()
    //{
    //    string fxName = this.GetImpactFX();

    //    Vector3 hitPos = transform.position;
    //    Quaternion hitRot = transform.rotation;
    //    Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
    //    fxImpact.gameObject.SetActive(true);
    //}
    //protected virtual string GetImpactFX()
    //{
    //    return FXSpawner.impact1;
    //}
}
