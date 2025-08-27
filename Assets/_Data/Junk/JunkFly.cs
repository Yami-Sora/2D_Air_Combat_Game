using UnityEngine;

public class JunkFly : ParentFly
{
    [SerializeField] protected float minCamPos = -16f;
    [SerializeField] protected float maxCamPos = 16f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        Vector3 objPos = this.transform.position;

        camPos.x += Random.Range(minCamPos, maxCamPos);
        camPos.y += Random.Range(minCamPos, maxCamPos);
        Vector3 dir = camPos - objPos;
        dir.Normalize();
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
        Debug.DrawLine(objPos, objPos + dir*7, Color.red, Mathf.Infinity);
    }
}
