using UnityEngine;

public class ObjMoveForward : ObjMovement
{
    [SerializeField] protected Transform moveTarget;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
    }
    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": LoadMoveTarget", gameObject);
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = moveTarget.position;
        this.targetPosition.z = 0;
    }
}
