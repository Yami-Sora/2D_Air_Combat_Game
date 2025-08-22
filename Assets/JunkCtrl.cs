using UnityEngine;

public class JunkCtrl : YamiMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;

    public JunkSpawner JunkSpawner { get => junkSpawner;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (JunkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner ", gameObject);
    }

}
