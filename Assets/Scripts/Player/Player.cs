using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private PlayerHandleInput _playerHandleInput;

    protected override void OnEnable()
    {
        base.OnEnable();
        _playerHandleInput = new PlayerHandleInput(this);
    }

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        _playerHandleInput.HandleInput();
    }
}
