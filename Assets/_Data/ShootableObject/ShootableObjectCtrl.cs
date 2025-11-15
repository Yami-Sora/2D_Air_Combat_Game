using UnityEngine;

public abstract class ShootableObjectCtrl : YamiMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] private ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;

    [SerializeField] private ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    [SerializeField] private ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;

    [SerializeField] private ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadLookAtTarget();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": LoadObjShooting", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = GetComponentInChildren<Despawn>();
        Debug.Log("LoadDespawn: " + transform.name, gameObject);
    }

    protected virtual void LoadSO()
    {
        if (shootableObject != null) return;
        string resPath = "ShootableObject/"+ this.GetObjectTypeString() +"/" + transform.name;
        shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log("LoadShootableObjectSO: " + resPath, gameObject);
    }
    protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();
        Debug.Log(transform.name + ": LoadObjMovement", gameObject);
    }
    protected virtual void LoadLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
        Debug.Log(transform.name + ": LoadObjLookAtTarget", gameObject);
    }
    protected abstract string GetObjectTypeString();
}
