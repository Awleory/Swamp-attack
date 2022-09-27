using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EntityPhysics))]
[RequireComponent(typeof(EntityStateMachine))]
[RequireComponent(typeof(JumpingState))]
[RequireComponent(typeof(StandingState))]
[RequireComponent(typeof(EntityAnimations))]
public class Entity : MonoBehaviour
{
    [SerializeField] private bool _hasHandleInput;
    [SerializeField] private float _maxHealthPoints;

    public float HealthPoints => _healthPoints;
    public bool HasHandleInput => _hasHandleInput;
    public JumpingState JumpingState => _jumpingState;
    public StandingState StandingState => _standingState;
    public EntityPhysics EntityPhysics { get; private set; }
    public EntityAnimations EntityAnimations { get; private set; }

    private EntityStateMachine _entityStateMachine;
    private JumpingState _jumpingState;
    private StandingState _standingState;

    private float _healthPoints;

    private void OnEnable()
    {
        EntityPhysics = GetComponent<EntityPhysics>();

        EntityAnimations = GetComponent<EntityAnimations>();
        EntityAnimations.Initialize(this);
    }

    private void Start()
    {
        _entityStateMachine = GetComponent<EntityStateMachine>();

        _standingState = GetComponent<StandingState>();
        _standingState.Initialize(this, _entityStateMachine);

        _jumpingState = GetComponent<JumpingState>();
        _jumpingState.Initialize(this, _entityStateMachine);

        _entityStateMachine.Initialize(_standingState);
    }

    private void Update()
    {
        _entityStateMachine.CurrentState.HandleInput();

        _entityStateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _entityStateMachine.CurrentState.PhysicsUpdate();
    }
}
