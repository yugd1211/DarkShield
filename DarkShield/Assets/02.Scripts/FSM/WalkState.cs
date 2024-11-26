using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WalkState : IState
{
	public Player _player;
	public WalkState(Player player)
	{
		this._player = player;
	}

	public void OnEnter()
	{
		_player.playerAnimator.SetBool("Walk", true);
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
		//Idle
		else if (_player.playerInputManager.InputMoveDir.magnitude < 0.1f)
		{
			_player.playerStateMachine.TransitionTo(_player.playerStateMachine.idleState);
		}
	}

	public void OnExit()
	{
		_player.playerAnimator.SetBool("Walk", false);
	}

}
