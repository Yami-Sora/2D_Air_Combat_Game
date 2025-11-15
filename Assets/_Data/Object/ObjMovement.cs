using UnityEngine;

public class ObjMovement : YamiMonoBehaviour
{
    [Header("Obj Movement")]
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.parent.position, this.targetPosition);
        if (this.distance < this.minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
