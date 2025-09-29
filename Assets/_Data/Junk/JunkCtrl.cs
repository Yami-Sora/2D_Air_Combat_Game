using UnityEngine;

public class JunkCtrl : YamiMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] public JunkSO junkSO;
    public JunkSO JunkSO { get => junkSO; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
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
        junkDespawn = GetComponent<JunkDespawn>();
        Debug.Log("LoadJunkDespawn: " + transform.name, gameObject);
    }

    protected virtual void LoadJunkSO()
    {
        if (junkSO != null) return;
        junkSO = Resources.Load<JunkSO>("_Data/Junk/JunkSO");
        Debug.Log("LoadJunkSO: " + transform.name, gameObject);
    }
}
