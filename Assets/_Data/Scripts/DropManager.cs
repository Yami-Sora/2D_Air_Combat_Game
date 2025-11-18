using UnityEngine;

public class DropManager : YamiMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.Log("Only one DropManager allow!");
        DropManager.instance = this;
    }
}
