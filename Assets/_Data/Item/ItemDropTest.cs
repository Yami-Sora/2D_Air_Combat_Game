using UnityEngine;

public class ItemDropTest : YamiMonoBehaviour
{
    public JunkCtrl junkCtrl;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Droping), 2f, 0.5f);
    }
    protected virtual void Droping()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropPot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropPot);
    }
}
