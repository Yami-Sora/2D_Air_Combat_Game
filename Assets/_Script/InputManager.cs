using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] public Vector3 mouseWorldPos;

    private void Awake()
    {
        InputManager.instance = this;
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
