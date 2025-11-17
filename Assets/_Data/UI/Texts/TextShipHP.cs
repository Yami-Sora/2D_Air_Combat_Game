using UnityEngine;

public class TextShipHP : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }
    protected virtual void UpdateShipHP()
    {
        this.text.SetText(Random.Range(1,111111).ToString());
        int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
        int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;

        this.text.SetText(hp.ToString() + " / " + hpMax.ToString());
    }
}
