using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode ability;
    public override void Pressed()
    {
        PlayerCtrl.Instance.PlayerAbility.Active(ability);
    }
}
