using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f; 
    [SerializeField] protected float shootTimer = 0f;

    private void FixedUpdate()
    {
        this.CheckIsShooting();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        if (this.shootTimer < this.shootDelay) 
        {
            this.shootTimer += Time.deltaTime;
            return;
        }

        this.shootTimer = 0f;
        Vector3 spawnPos = transform.position; 
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne,spawnPos, rotation);
        if (newBullet == null)
        {
            Debug.LogError("Failed to spawn bullet. Check if the prefab is set up correctly.");
            return;
        }   
        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        //bulletCtrl.SetShooter(transform.parent);
    }

    protected virtual void CheckIsShooting()
    {
        if (InputManager.Instance.OnFiring != 0) this.isShooting = true;
        else this.isShooting = false;
    }
}
