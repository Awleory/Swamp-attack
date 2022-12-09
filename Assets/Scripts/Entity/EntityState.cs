using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EntityState
{
    protected Entity Entity;
    protected EntityStateMachine StateMachine;

    protected EntityState(Entity entity, EntityStateMachine stateMachine)
    {
        Entity = entity;
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }
    
    public virtual void Exit() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        Entity.EntityPhysics.UpdateMove();
    }
}
