using Unity.VisualScripting;
using UnityEngine;

public class HPBar : YamiMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }
    protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponentInParent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;
        if (this.shootableObjectCtrl.DamageReceiver.IsDead())
        {
            this.spawner.Despawn(transform);
            return;
        }
        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float maxHP = this.shootableObjectCtrl.ShootableObject.HPMax;

        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetMaxHP(maxHP);
    }

    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}
