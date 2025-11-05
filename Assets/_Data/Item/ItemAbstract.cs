using UnityEngine;

public abstract class ItemAbstract : YamiMonoBehaviour
{
    [SerializeField] private ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl { get => itemCtrl; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCtrl();
    }
    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = GetComponentInParent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }
}
