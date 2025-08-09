using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }
    public static string BulletOne = "Bullet_1";
    public static string BulletTwo = "Bullet_2";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
            Debug.LogError("BulletSpawner already exists in the scene.");
        BulletSpawner.instance = this;
    }
}
