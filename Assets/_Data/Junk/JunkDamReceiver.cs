using UnityEngine;
using UnityEngine.VFX;

public class JunkDamReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log("LoadJunkCtrl: " + transform.name, gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.junkCtrl.JunkDespawn.DespawnObject();
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
        this.hpMax = 2;
        base.Reborn();
    }
}
