using UnityEngine;

public abstract class BaseAbilities : YamiMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
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
