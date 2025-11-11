using UnityEngine;

public class Abilities : YamiMonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] private AbilityObjectCtrl abilityObjectCtrl;

    public AbilityObjectCtrl AbilityObjectCtrl => abilityObjectCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjectCtrl();
    }
    protected virtual void LoadAbilityObjectCtrl()
    {
        if (this.abilityObjectCtrl != null) return;
        this.abilityObjectCtrl = GetComponentInParent <AbilityObjectCtrl>();
        Debug.Log(transform.name + ": LoadAbilityObjectCtrl", gameObject);
    }
}
