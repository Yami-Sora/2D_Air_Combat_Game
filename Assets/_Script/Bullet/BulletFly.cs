using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected int movespeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void FixedUpdate()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}
