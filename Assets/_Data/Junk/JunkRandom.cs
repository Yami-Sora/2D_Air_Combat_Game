using UnityEngine;

public class JunkRandom : YamiMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkCtrl;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl ", gameObject);
    }
    protected override void Start()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkCtrl.JunkSpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);

        Invoke(nameof(JunkSpawning), 0.5f);
    }
}
