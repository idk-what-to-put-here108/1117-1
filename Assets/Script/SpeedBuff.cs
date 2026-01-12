using UnityEngine;

public class SpeedBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().speed
    }
}
