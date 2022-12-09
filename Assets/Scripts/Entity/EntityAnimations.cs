using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class EntityAnimations : MonoBehaviour
{
    [SerializeField] private bool _flipX;

    public Animator Animator { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }

    private Entity Entity;
    private float _previousFrameX;

    private int _speedParameter = Animator.StringToHash("VelocityX");
    private int _jumpingParameter = Animator.StringToHash("Jump");
    private int _landingParameter = Animator.StringToHash("Land");

    private void OnEnable()
    {
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Entity = GetComponent<Entity>();

        _previousFrameX = transform.position.x;
    }

    private void Update()
    {
        CheckFlipX(_flipX);

        Animator.SetFloat(_speedParameter, Math.Abs(Entity.EntityPhysics.VelocityX));
    }

    public void PlayJump()
    {
        Animator.SetTrigger(_jumpingParameter);
    }

    public void PlayLanding()
    {
        Animator.SetTrigger(_landingParameter);
    }

    private void CheckFlipX(bool flipX)
    {
        if (SpriteRenderer.flipX == flipX && transform.position.x < _previousFrameX
            || SpriteRenderer.flipX != flipX && transform.position.x > _previousFrameX)
        {
            SpriteRenderer.flipX = !SpriteRenderer.flipX;
        }

        _previousFrameX = transform.position.x;
    }
}
