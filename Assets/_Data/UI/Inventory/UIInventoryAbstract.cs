using UnityEngine;

public abstract class UIInventoryAbstract : YamiMonoBehaviour
{
    [Header("Inventory Absrtact")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

    protected override void LoadComponents()
    {
        this.LoadUIInventoryCtrl();
        base.LoadComponents();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = GetComponentInParent<UIInventoryCtrl>(true);
        Debug.LogWarning(transform.name + ":LoadUIInventoryCtrl", gameObject);
    }

}
