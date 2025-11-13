using UnityEngine;

public class ObjLookAtTarget : YamiMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 3f;

    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
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
