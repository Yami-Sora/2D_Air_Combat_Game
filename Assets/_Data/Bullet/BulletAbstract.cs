using UnityEngine;

public abstract class BulletAbstract : YamiMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] private BulletCtrl bulletCtrl;

    protected BulletCtrl BulletCtrl { get => bulletCtrl;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log("LoadDamageReceiver: " + transform.name, gameObject);
    }
}
