using UnityEngine;

public class EagleEnemy : Character
{
    [SerializeField] private float patrolDistance = 5f;

    protected override void Awake()
    {
        base.Awake();
    }
}
