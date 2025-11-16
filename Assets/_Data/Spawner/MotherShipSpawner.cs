using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null)
            Debug.LogError("MotherShipSpawner already exists in the scene.");
        MotherShipSpawner.instance = this;
    }
}
