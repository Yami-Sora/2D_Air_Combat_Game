using UnityEngine;

public abstract class ObjAppearing : YamiMonoBehaviour
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool isAppearing = false;

    [SerializeField] private bool appeared = false;

    public bool IsAppearing => isAppearing;

    public bool Appeared => appeared;

    protected virtual void FixedUpdate()
    {
        this.Appear();
        this.Appearing();
    }
    protected abstract void Appearing();
    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
    }
}
