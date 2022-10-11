
using System;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private Entity _target;

    public Entity Target => Target;
    public EnemyIdleState IdleState { get; private set; }
    public EnemyPursueState ChasingState { get; private set; }

    public void SetTarget(Entity target)
    {
        _target = target;
    }
}
