using UnityEngine;

public class ShipShootByDistance : ObjShooting
{
    [Header("Shoot By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3f;
    //[SerializeField] protected Vector3 scaleCondiions = new Vector3(1, 1, 1);

    protected override string BulletName()
    {
        return "Bullet_2";
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override void CheckIsShooting()
    {

        this.distance = Vector3.Distance(this.transform.position, this.target.position);
        //if (this.distance < shootDistance && (transform.parent.localScale == scaleCondiions)) this.isShooting = true;
        if (this.distance < shootDistance) this.isShooting = true;
        else this.isShooting = false;
    }
}
