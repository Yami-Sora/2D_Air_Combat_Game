using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbstract, IObjAppearObserver
{
    [Header("Obj Appear Without Shoot")]
    [SerializeField] protected ObjAppearing objAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();
    }
    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null) return;
        this.objAppearing = GetComponent<ObjAppearing>();
        Debug.Log(transform.name + ": LoadObjAppearing", gameObject);
    }
    protected virtual void RegisterAppearEvent()
    {
        this.objAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.ShootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.ShootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
    }
}
