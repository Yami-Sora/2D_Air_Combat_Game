using UnityEngine;
using UnityEngine.VFX;

public class ShootableObjectDamReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }
    protected virtual void LoadShootableObjectCtrl()
    {
        if (shootableObjectCtrl != null) return;
        shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log("LoadJunkCtrl: " + transform.name, gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.DropOnDead();
        this.shootableObjectCtrl.Despawn.DespawnObject();
    }
    protected virtual void DropOnDead()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropPot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObject.dropList, dropPos, dropPot);
    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
    public override void Reborn()
    {
        this.hpMax = shootableObjectCtrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
