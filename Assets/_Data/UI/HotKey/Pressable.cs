using UnityEngine;

public class Pressable : YamiMonoBehaviour
{
    public virtual void Pressed()
    {
        Debug.Log("Pressed: "+transform.parent.parent.name);
    }
}
