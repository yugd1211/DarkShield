using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IState
{
    private Player _player;

    public DashState(Player player)
    {
        _player = player;
    }
    public void OnEnter()
    {
        _player.playerMovement.Dash();
        //대쉬가 호출되고 끝나면 idle로 가게 여기서 트랜지션해줘야 함.
        _player.playerAnimator.SetTrigger("Dash");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }

    public void EndDash()
    {
        _player.playerStateMachine.TransitionTo(_player.playerStateMachine.idleState);
    }
}
