using UnityEngine;

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
        this.junkCtrl.JunkDespawn.DespawnObject();
    }

}
