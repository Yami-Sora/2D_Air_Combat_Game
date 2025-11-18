using UnityEngine;

public abstract class BaseAbilities : YamiMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] private Abilities abilities;
    protected Abilities Abilities => abilities;

    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 5f;
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Update()
    {
        //For override
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = GetComponentInParent<Abilities>(true);
        Debug.Log(transform.name + ": LoadAbilities", gameObject);
    }
    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }
    public virtual void Active()
    {
        this.isReady = false;
        this.timer = 0f;
    }
}
