//using UnityEngine;

//public class UIManager : YamiMonoBehaviour
//{
//    private static UIManager instance;
//    public static UIManager Instance => instance;
//    public UIInventory inventory;

//    protected override void Awake()
//    {
//        base.Awake();
//        if (UIManager.instance != null) Debug.LogWarning("Multiple instances of UIManager detected!");
//        UIManager.instance = this;
//    }
//    protected override void LoadComponents()
//    {
//        base.LoadComponents();
//        this.LoadUIInventory();
//    }
//    protected virtual void LoadUIInventory()
//    {
//        if (this.inventory != null) return;
//        this.inventory = transform.Find("Canvas/UICenter/UIInventory")?.GetComponent<UIInventory>();
//        if (this.inventory == null)
//        {
//            Debug.LogError("UIInventory component not found in UIManager!");
//        }
//    }
//}
