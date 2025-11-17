using UnityEngine;
using UnityEngine.UI;

public class HPBar : YamiMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHP sliderHP;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
    }
    protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }
    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;
        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float maxHP = this.shootableObjectCtrl.ShootableObject.HPMax;

        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetMaxHP(maxHP);
    }

    public virtual void SetShootableObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
}
