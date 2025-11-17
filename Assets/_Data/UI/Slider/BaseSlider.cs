using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : YamiMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        base.Start();
        this.AddOnChangedEvent();
    }
    protected virtual void FixedUpdate()
    {
        //For override
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = this.GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }
    protected virtual void AddOnChangedEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }
    protected abstract void OnChanged(float newValue);
}
