using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
            Debug.LogError("BulletSpawner already exists in the scene.");
        BulletSpawner.instance = this;
    }
}
