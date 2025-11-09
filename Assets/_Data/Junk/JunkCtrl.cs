using UnityEngine;

public class JunkCtrl : YamiMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] private ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject { get => shootableObject; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadShootableObjectSO();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = GetComponentInChildren<JunkDespawn>();
        Debug.Log("LoadJunkDespawn: " + transform.name, gameObject);
    }

    protected virtual void LoadShootableObjectSO()
    {
        if (shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name;
        shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log("LoadShootableObjectSO: " + resPath, gameObject);
    }
}
