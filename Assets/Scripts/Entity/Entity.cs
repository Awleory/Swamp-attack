using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MovementPhysics))]
[RequireComponent(typeof(AnimationController))]
public class Entity : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private int _maxHealthPoints;

    public event Action GotDamage;
    public event Action Died;

    public MovementPhysics MovementPhysics { get; private set; }
    public AnimationController AnimationController { get; private set; }
    public bool IsAlive => _healthPoints > 0;

    private float _healthPoints;
    private float _deathTime = 10;

    protected virtual void Awake()
    {
        MovementPhysics = GetComponent<MovementPhysics>();
        AnimationController = GetComponent<AnimationController>();

        _healthPoints = _maxHealthPoints;
    }

    protected virtual void OnEnable()
    {
        MovementPhysics.Moved += OnMoved;
    }

    protected virtual void OnDisable()
    {
        MovementPhysics.Moved -= OnMoved;
    }

    protected virtual void Update()
    {
        _currentHealth = _healthPoints;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        if (IsAlive == false)
            return;

        _healthPoints = Math.Max(0, _healthPoints - damage);
        GotDamage?.Invoke();
        AnimationController.PlayGettingDamage();

        if (_healthPoints == 0)
            Kill();
    }

    public void Kill()
    {
        Died?.Invoke();
        AnimationController.PlayDeath();
        OnDied();
        StartCoroutine(DeathCoroutine());
    }

    protected virtual void OnDied() { }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }

    private void OnMoved(float velocityX)
    {
        AnimationController.OnMove(Mathf.Abs(velocityX));
    }
}