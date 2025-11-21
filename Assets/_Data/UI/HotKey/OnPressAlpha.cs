using UnityEngine;

public class OnPressAlpha : MonoBehaviour
{
    protected void Update()
    {
        this.CheckAlphaIsPress();
    }
    protected virtual void CheckAlphaIsPress()
    {
        if (InputHotKeyManager.Instance.isAlpha1) Debug.Log("Key 1");
        if (InputHotKeyManager.Instance.isAlpha2) Debug.Log("Key 2");
        if (InputHotKeyManager.Instance.isAlpha3) Debug.Log("Key 3");
        if (InputHotKeyManager.Instance.isAlpha4) Debug.Log("Key 4");
        if (InputHotKeyManager.Instance.isAlpha5) Debug.Log("Key 5");
        if (InputHotKeyManager.Instance.isAlpha6) Debug.Log("Key 6");
        if (InputHotKeyManager.Instance.isAlpha7) Debug.Log("Key 7");
    }
}
