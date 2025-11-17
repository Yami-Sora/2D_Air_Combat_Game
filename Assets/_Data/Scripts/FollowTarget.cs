using UnityEngine;

public class FollowTarget : YamiMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }
    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(this.target.position.x, this.target.position.y, transform.position.z),
            this.speed * Time.fixedDeltaTime);
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
