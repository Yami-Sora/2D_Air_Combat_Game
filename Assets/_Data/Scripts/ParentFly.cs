using UnityEngine;

public class ParentFly : YamiMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void FixedUpdate()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
