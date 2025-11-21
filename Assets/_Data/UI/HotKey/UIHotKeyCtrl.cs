using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class UIHotKeyCtrl : YamiMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    public List<ItemSlot> itemSlots;

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Multiple instances of UIHotKeyCtrl detected!");
        UIHotKeyCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlot();
    }
    protected virtual void LoadItemSlot()
    {
        if (itemSlots.Count > 0) return;
        ItemSlot[] arraySlots = GetComponentsInChildren<ItemSlot>();
        foreach (ItemSlot slot in arraySlots)
        {
            Debug.Log("IteamSlot: " + slot.name);
        }
        this.itemSlots.AddRange(arraySlots);

        Debug.LogWarning(transform.name + ": LoadItemSlots", gameObject);
    }
}
