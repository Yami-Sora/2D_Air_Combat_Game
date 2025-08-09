using UnityEngine;

public class YamiMonoBehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Start()
    {
        //For override
    }
    protected virtual void LoadComponents()
    {
        //for override  
    }
}
