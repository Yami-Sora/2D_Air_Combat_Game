using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 50f;
    [SerializeField] protected float distance = 0f;

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.transform.position, GameCtrl.Instance.MainCamera.transform.position);
        if(this.distance > this.disLimit) return true;
        return false;
    }
}
