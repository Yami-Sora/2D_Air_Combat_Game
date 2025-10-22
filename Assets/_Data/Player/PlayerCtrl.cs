using UnityEngine;

public class PlayerCtrl : YamiMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance;}

    [SerializeField] private ShipCtrl currentShip;
    public ShipCtrl CurrentShip { get => currentShip; }

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup { get => playerPickup; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one PlayerCtrl allow in scene");
        PlayerCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickUp();
    } 
    protected virtual void LoadPlayerPickUp()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log($"PlayerCtrl: LoadPlayerPickUp in {gameObject.name}", gameObject);
    }
}
