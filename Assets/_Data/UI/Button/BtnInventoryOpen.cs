using UnityEngine;

public class BtnInventoryOpen : BaseButton
{
    protected override void OnClick()
    {
        if (UIInventory.Instance == null)
        {
            Debug.LogError("UIInventory is missing in the scene!");
            return;
        }
        UIInventory.Instance.Toggle();
    }
}
