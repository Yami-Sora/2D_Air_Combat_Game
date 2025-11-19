using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : YamiMonoBehaviour
{
    [Header("UI Item Inventory")]
    [SerializeField] private TMP_Text itemName;
    public TMP_Text ItemName => itemName;

    [SerializeField]  private TMP_Text itemNumber;
    public TMP_Text ItemNumber => itemNumber;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
    }
    protected virtual void LoadItemName()
    {
        if(this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<TMP_Text>();
        Debug.LogWarning(transform.name + "LoadItemName", gameObject);
    }
    protected virtual void LoadItemNumber()
    {
        if(this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemCount").GetComponent<TMP_Text>();
        Debug.LogWarning(transform.name + "LoadItemNumber", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemName.text = item.itemProfile.name;
        this.itemNumber.text = item.itemCount.ToString();
    }
}
