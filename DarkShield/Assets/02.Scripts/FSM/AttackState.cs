using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
	private Player _player;

	public AttackState(Player player)
	{
		_player = player;
	}

	public void OnEnter()
	{
		_player._curWeopon.SlashAttack();
		_player.playerAnimator.SetTrigger("Slash");
	}

	public void OnUpdate()
	{

	}

	public void OnExit()
	{
		_player.playerInputManager.isSlash = false;
	}

	public void EndAttack()
	{
		_player.playerStateMachine.TransitionTo(_player.playerStateMachine.idleState);
	}

}
