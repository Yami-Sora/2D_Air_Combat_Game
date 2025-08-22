using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance;}

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring;}
    private void Awake()
    {
        if(InputManager.instance != null) 
            Debug.LogError("InputManager already exists in the scene. Please ensure there is only one instance.");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
