using UnityEngine;

public class ShipShootingByMouse : ShipShooting
{
    protected override string BulletName()
    {
        return "Bullet_1";
    }
    protected override void CheckIsShooting()
    {
        if (InputManager.Instance.OnFiring != 0) this.isShooting = true;
        else this.isShooting = false;
    }
}
