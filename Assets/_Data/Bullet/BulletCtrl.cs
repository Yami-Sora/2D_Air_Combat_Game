using UnityEngine;

public class BulletCtrl : YamiMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }
    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;
        damageSender = GetComponent<DamageSender>();
        Debug.Log("LoadDamageSender: " + transform.name, gameObject);
    }
}
