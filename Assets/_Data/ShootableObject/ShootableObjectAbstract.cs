using UnityEngine;

public abstract class ShootableObjectAbstract : YamiMonoBehaviour
{
    [SerializeField] private ShootableObjectCtrl shootableObjectctrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectctrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }
    
    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectctrl != null) return;
        this.shootableObjectctrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.LogWarning($"[ShootableObjectAbstract] LoadShootableObjectCtrl in {gameObject.name}", gameObject);
    }
}
