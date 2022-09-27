using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : EntityState
{
    private bool _grounded;

    public override void Enter()
    {
        base.Enter();

        _grounded = false;
        Entity.EntityAnimations.PlayJump();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_grounded)
        {
            Entity.EntityAnimations.PlayLanding();
            StateMachine.ChangeState(Entity.StandingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _grounded = Entity.EntityPhysics.Grounded;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
