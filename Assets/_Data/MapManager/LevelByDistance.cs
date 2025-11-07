using UnityEngine;

public class LevelByDistance : Level
{
    [Header("By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float distancePerLevel = 10f;
    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }
    public virtual void SetTarget(Transform Target)
    {
        this.target = Target;
    }
    protected virtual void Leveling()
    {
        if (this.target == null) return;
        this.distance = Vector3.Distance(this.transform.position, this.target.position);
        int newLevel = this.GetLevelByDis();
        this.LetvelSet(newLevel);
    }
    protected virtual int GetLevelByDis()
    {
        return Mathf.FloorToInt(this.distance / this.distancePerLevel) + 1;
    }
}
