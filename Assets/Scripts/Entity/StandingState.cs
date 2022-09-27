using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : EntityState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Entity.EntityPhysics.TryJump())
            {
                StateMachine.ChangeState(Entity.JumpingState);
            }
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
