using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f; 
    [SerializeField] protected float shootTimer = 0f;

    private void FixedUpdate()
    {
        this.checkIsShooting();
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
        Transform newBullet = Spawner.instance.Spawn(spawnPos, rotation);
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shooting");
    }

    protected virtual void checkIsShooting()
    {
        if (InputManager.Instance.OnFiring != 0) this.isShooting = true;
        else this.isShooting = false;
    }
}
