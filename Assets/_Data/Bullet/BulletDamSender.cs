using UnityEngine;

public class BulletDamSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log("LoadBulletCtrl: " + transform.name, gameObject);
    }
    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }
    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
