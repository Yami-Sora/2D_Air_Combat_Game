using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }
    public static string meteoriteOne = "Meteorite_1";
    public static string meteoriteTwo = "Meteorite_2";

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null)
            Debug.LogError("JunkSpawner already exists in the scene.");
        JunkSpawner.instance = this;
    }
}
