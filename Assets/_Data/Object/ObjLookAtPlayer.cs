using UnityEngine;

public class ObjLookAtPlayer : ObjLookAtTarget
{
    [Header("Obj LookAt Player")]
    [SerializeField] protected GameObject player;

    protected override void FixedUpdate()
    {
        this.GetPlayerPosition();
        base.FixedUpdate();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindWithTag("Player");
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }
    protected virtual void GetPlayerPosition()
    {
        if (this.player == null) return;
        this.targetPosition = player.transform.position;
        this.targetPosition.z = 0;
    }
}
