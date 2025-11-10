using UnityEngine;

public class BulletCtrl : YamiMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn;}


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }
    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;
        damageSender = GetComponent<DamageSender>();
        Debug.Log("LoadDamageSender: " + transform.name, gameObject);
    }
    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = GetComponent<BulletDespawn>();
        Debug.Log("LoadBulletDespawn: " + transform.name, gameObject);
    }
}
