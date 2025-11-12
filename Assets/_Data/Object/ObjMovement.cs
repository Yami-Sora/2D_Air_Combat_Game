using UnityEngine;

public class ObjMovement : YamiMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected float rotSpeed = 3f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float minDistance = 1f;

    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.parent.position, this.targetPosition);
        if (this.distance < this.minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.speed);
        transform.parent.position = newPos;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 direction = targetPosition - transform.parent.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0, 0, angle);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
        transform.parent.rotation = currentEuler;
    }
}
