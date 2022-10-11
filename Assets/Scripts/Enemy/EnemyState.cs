using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : EntityState
{
    public Enemy Enemy { get; private set; }

    public EnemyState(Enemy enemy, EntityStateMachine stateMachine) : base(enemy, stateMachine)
    {
        Enemy = enemy;
    }
}
