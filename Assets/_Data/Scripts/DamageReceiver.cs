using UnityEngine;

public class DamageReceiver : YamiMonoBehaviour
{
    [SerializeField] protected float hp = 1;
    [SerializeField] protected float hpMax = 1;

    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }
    public virtual void Reborn()
    {
        this.hp = this.hpMax;
    }
    public virtual void Add(float add)
    {
        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }
    public virtual void Deduct(float deduct)
    {
        this.hp -= deduct;
        if (this.hp <= 0) this.hp = 0;
    }
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
}
