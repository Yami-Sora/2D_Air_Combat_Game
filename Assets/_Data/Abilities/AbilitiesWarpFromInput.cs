using UnityEngine;

public class AbilitiesWarpFromInput : AbilityWarp
{
    protected override void Update()
    {
        this.UpdateKeyDirection();
        base.Update();
    }
    protected virtual void UpdateKeyDirection()
    {
        this.keyDirection = InputManager.Instance.Direction;
    }
}
