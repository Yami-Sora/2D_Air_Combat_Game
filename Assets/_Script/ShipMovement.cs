using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        this.worldPosition = InputManager.instance.mouseWorldPos;
        this.worldPosition.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.worldPosition, this.speed);
        transform.parent.position = newPos;
    }
}
