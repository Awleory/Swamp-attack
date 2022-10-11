using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursueState : EnemyState
{
    public EnemyPursueState(Enemy enemy, EntityStateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Enemy.Target == null)
        {
            StateMachine.ChangeState(Enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        PursueTarget();
    }
    public void PursueTarget()
    {
        Enemy.transform.LookAt(Enemy.Target.transform);
    }
}
