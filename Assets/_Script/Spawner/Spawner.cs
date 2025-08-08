using System.Collections.Generic;
using UnityEngine;

public class Spawner : YamiMonoBehavior
{
    public static Spawner instance { get; private set; }
    [SerializeField] protected List<Transform> prefabs = new List<Transform>();

    protected override void Awake()
    {
        base.Awake();
        Spawner.instance = this;
    }
    protected override void Reset()
    {
        this.LoadComponents();
    }

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + ":LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.prefabs[0];
        Transform newprefab = Instantiate(prefab, spawnPos, rotation);
        return newprefab;
    }
}
