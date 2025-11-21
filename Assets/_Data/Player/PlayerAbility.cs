using UnityEngine;

public class PlayerAbility : YamiMonoBehaviour
{
    public virtual void Active(AbilitiesCode abilitiesCode)
    {
        Debug.Log("AbilitiesCode: " + abilitiesCode.ToString());
    }
}
