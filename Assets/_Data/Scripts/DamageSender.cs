using UnityEngine;

public class DamageSender : YamiMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(GameObject obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
    
}
