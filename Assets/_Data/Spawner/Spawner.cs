using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : YamiMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount { get => this.spawnedCount; }   

    [SerializeField] protected List<Transform> prefabs = new List<Transform>();
    [SerializeField] protected List<Transform> poolObjs = new List<Transform>();



    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ":LoadHolder", gameObject);
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
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.SetParent(this.holder);
        this.spawnedCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        for (int i = 0; i < this.poolObjs.Count; i++)
        {
            Transform poolObj = this.poolObjs[i];
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.RemoveAt(i);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        if (obj == null || obj == this.transform)
            return;

        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
        }
        Debug.LogWarning("Prefab with name " + prefabName + " not found in " + transform.name);
        return null;
    }
    public virtual Transform RandomPrefab()
    {
        if (this.prefabs.Count == 0) return null;
        int index = Random.Range(0, this.prefabs.Count);
        return this.prefabs[index];
    }
    public virtual void Hold(Transform obj)
    {
        if (obj == null || obj == this.transform)
            return;
        obj.parent = this.holder;
    }
}
