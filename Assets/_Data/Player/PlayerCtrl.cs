using UnityEngine;

public class PlayerCtrl : YamiMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance;}

    [SerializeField] private ShipCtrl currentShip;
    public ShipCtrl CurrentShip { get => currentShip; }

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup { get => playerPickup; }

    [SerializeField] protected PlayerAbility playerAbility;
    public PlayerAbility PlayerAbility { get => playerAbility; }

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
        this.LoadPlayerAbility();
    } 
    protected virtual void LoadPlayerPickUp()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log($"PlayerCtrl: LoadPlayerPickUp in {gameObject.name}", gameObject);
    }
    protected virtual void LoadPlayerAbility()
    {
        if (this.playerAbility != null) return;
        this.playerAbility = transform.GetComponentInChildren<PlayerAbility>();
        Debug.Log($"PlayerCtrl: LoadPlayerAbility in {gameObject.name}", gameObject);
    }
}
