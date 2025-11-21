using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class ItemSlot : YamiMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragItem dragItem = eventData.pointerDrag.GetComponent<DragItem>();
        dragItem.DroppedOnSlot = true;

        if (transform.childCount > 0)
            Swap(this.transform.GetChild(0), dragItem);

        dragItem.transform.SetParent(transform, false);
    }
    protected virtual void Swap(Transform slotChild, DragItem dragItem)
    {
        Transform parentA = slotChild.parent;
        Transform parentB = dragItem.RealParent;

        slotChild.SetParent(parentB, false);
        dragItem.RealParent = parentA;
    }
}
