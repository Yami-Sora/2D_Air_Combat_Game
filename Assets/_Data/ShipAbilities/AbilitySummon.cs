using UnityEngine;

public class AbilitySummon : BaseAbilities
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }
    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        this.Summon();
    }
    protected virtual void Summon()
    {
        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, transform.position, transform.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
    }

}
