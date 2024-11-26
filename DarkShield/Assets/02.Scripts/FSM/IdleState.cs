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
		//Slash
		if (_player.playerInputManager.isSlash)
		{
			_player.playerStateMachine.TransitionTo(_player.playerStateMachine.attackState);
		}
		//Skill
		else if (_player.playerInputManager.isSkill)
		{
			_player.playerStateMachine.TransitionTo(_player.playerStateMachine.attackState);
		}
		//Dash
		else if (_player.playerInputManager.isDash)
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
