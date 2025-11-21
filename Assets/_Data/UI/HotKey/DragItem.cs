using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : YamiMonoBehaviour, IBeginDragHandler,IDragHandler ,IEndDragHandler
{
    [SerializeField] protected Image image;
    [SerializeField] private Transform realParent;
    public Transform RealParent { get => realParent; set => realParent = value; }

    public bool DroppedOnSlot { get; set; } = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage", gameObject);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        this.RealParent = transform.parent;
        transform.SetParent(UIHotKeyCtrl.Instance.transform, false);
        this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        this.transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        if (!DroppedOnSlot)
            transform.SetParent(RealParent, false);

        image.raycastTarget = true;

        DroppedOnSlot = false; // reset
    }
}
