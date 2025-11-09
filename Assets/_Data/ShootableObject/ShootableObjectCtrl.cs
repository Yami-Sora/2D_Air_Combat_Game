using UnityEngine;

public abstract class ShootableObjectCtrl : YamiMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] private ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
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
    protected abstract string GetObjectTypeString();
}
