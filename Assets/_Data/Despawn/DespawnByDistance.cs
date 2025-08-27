using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 20f;
    [SerializeField] protected float distance = 0f;
    //[SerializeField] protected Camera mainCam;

    //protected override void LoadComponents()
    //{
    //    this.LoadCamera();
    //}
    //protected virtual void LoadCamera()
    //{
    //    if (this.mainCam != null) return;
    //    this.mainCam = Camera.main;
    //    Debug.Log("Main Camera Loaded");
    //}

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.transform.position, GameCtrl.Instance.MainCamera.transform.position);
        if(this.distance > this.disLimit) return true;
        return false;
    }
}
