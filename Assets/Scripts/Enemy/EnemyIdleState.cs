using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EntityStateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Enemy.Target != null)
        {
            StateMachine.ChangeState(Enemy.ChasingState);
        }
    }
}
