using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EntityPhysics))]
[RequireComponent(typeof(EntityAnimations))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] private float _maxHealthPoints;

    public float HealthPoints => _healthPoints;
    public JumpingState JumpingState => _jumpingState;
    public StandingState StandingState => _standingState;
    public EntityPhysics EntityPhysics { get; private set; }
    public EntityAnimations EntityAnimations { get; private set; }
    public EntityStateMachine EntityStateMachine { get; private set; }

    private EntityStateMachine _entityStateMachine;
    private JumpingState _jumpingState;
    private StandingState _standingState;

    private float _healthPoints;

    protected virtual void OnEnable()
    {
        EntityPhysics = GetComponent<EntityPhysics>();
        EntityAnimations = GetComponent<EntityAnimations>();
    }

    protected virtual void Start()
    {
        _entityStateMachine = new EntityStateMachine();

        _standingState = new StandingState(this, _entityStateMachine);
        _jumpingState = new JumpingState(this, _entityStateMachine);

        _entityStateMachine.Initialize(_standingState);
    }

    private void Update()
    {
        _entityStateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _entityStateMachine.CurrentState.PhysicsUpdate();
    }
}
