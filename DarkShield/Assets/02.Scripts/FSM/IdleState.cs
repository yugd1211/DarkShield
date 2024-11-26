using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class IdleState : IState
{
    private Player _player;

    public IdleState(Player player)
    {
        this._player = player;
    }
    public void OnEnter()
    {
    }

    public void OnUpdate()
    {
        //NormalAttack
        if (_player.isLeftMouseClick == true)
        {
            _player.playerStateMachine.TransitionTo(_player.playerStateMachine.attackState);
        }
        //SkillAttack
        else if (_player.isRightMouseClick == true)
        {
            _player.playerStateMachine.TransitionTo(_player.playerStateMachine.attackState);
        }
        //Dash
        else if (_player.playerInputManager.DashPressed == true)
        {
            _player.playerStateMachine.TransitionTo(_player.playerStateMachine.dashState);
        }
        //Move
        else if (_player.playerInputManager.InputMoveDir.magnitude >= 0.1f)
        {
            _player.playerStateMachine.TransitionTo(_player.playerStateMachine.walkState);
        }
    }

    public void OnExit()
    {

    }

}
