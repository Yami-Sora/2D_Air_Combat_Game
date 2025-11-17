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

    [SerializeField] private Spawner spawner;    
    public Spawner Spawner => spawner;

    [SerializeField] private DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadLookAtTarget();
        this.LoadSpawner();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.LogWarning(transform.name + ": LoadObjShooting", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = GetComponentInChildren<Despawn>();
        Debug.LogWarning("LoadDespawn: " + transform.name, gameObject);
    }

    protected virtual void LoadSO()
    {
        if (shootableObject != null) return;
        string resPath = "ShootableObject/"+ this.GetObjectTypeString() +"/" + transform.name;
        shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning("LoadShootableObjectSO: " + resPath, gameObject);
    }
    protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();
        Debug.LogWarning(transform.name + ": LoadObjMovement", gameObject);
    }
    protected virtual void LoadLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
        Debug.LogWarning(transform.name + ": LoadObjLookAtTarget", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponentInParent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }
    protected abstract string GetObjectTypeString();
}
