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

		_player.playerAnimator.SetTrigger("Dash");
	}

	public void OnUpdate()
	{

	}

	public void OnExit()
	{
		_player.playerInputManager.isDash = false;
	}

	public void EndDash()
	{
		_player.playerStateMachine.TransitionTo(_player.playerStateMachine.idleState);
	}
}
