using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerHandleInput
{
    private Player _player;

    public PlayerHandleInput(Player player)
    {
        _player = player;
    }

    public void HandleInput()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);
        _player.EntityPhysics.GiveMovement(move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_player.EntityPhysics.TryJump())
            {
                _player.EntityStateMachine.ChangeState(_player.JumpingState);
            }
        }
    }
}
