using System.Collections.Generic;
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
    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }
}
