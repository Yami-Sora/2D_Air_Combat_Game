using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        this.GetTargetPosition();
        this.Moving();
        this.LookAtTarget();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.speed);
        transform.parent.position = newPos;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 direction = targetPosition - transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, angle);
    }
}
