using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : EntityState
{
    private bool _grounded;

    public JumpingState(Entity entity, EntityStateMachine stateMachine) : base(entity, stateMachine) { }

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
}
