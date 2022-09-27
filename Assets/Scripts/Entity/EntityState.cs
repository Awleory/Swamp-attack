using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EntityState : MonoBehaviour
{
    protected Entity Entity;
    protected EntityStateMachine StateMachine;

    public virtual void Initialize(Entity entity, EntityStateMachine stateMachine)
    {
        Entity = entity;
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void HandleInput()
    {
        if (Entity.HasHandleInput)
        {
            Entity.EntityPhysics.GetHandleInput();
        }
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        Entity.EntityPhysics.UpdateMove();
    }

    public virtual void Exit() { }
}
