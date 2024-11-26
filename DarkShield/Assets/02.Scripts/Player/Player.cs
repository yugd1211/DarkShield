using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	public Weapon _curWeopon;
	public StateMachine playerStateMachine;
	public PlayerMovement playerMovement;
	public PlayerInputManager playerInputManager;
	public Animator playerAnimator;

	private void Awake()
	{
		Init();
	}

	private void Start()
	{
		playerStateMachine.Init(playerStateMachine.idleState);
	}

	private void Update()
	{
		if (playerStateMachine.CurState != playerStateMachine.attackState && playerStateMachine.CurState != playerStateMachine.dashState)
		{
			playerMovement.Move(playerInputManager.InputMoveDir);
		}
		playerStateMachine.OnUpdate();
	}

	private void Init()
	{
		_curWeopon = GetComponentInChildren<Weapon>();
		playerStateMachine = new StateMachine(this);
		playerMovement = GetComponent<PlayerMovement>();
		playerInputManager = GetComponent<PlayerInputManager>();
		playerAnimator = GetComponent<Animator>();
	}

	// 임시로 설정 포탈 이동
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Portal"))
		{
			StageManager.Instance.ChangeStage(StageManager.Instance.currStage.nextStage);
		}
	}

	#region 애니메이션 이벤트 함수
	public void EndDash()
	{
		playerStateMachine.dashState.EndDash();
	}

	public void EndSlashAttack()
	{
		playerStateMachine.attackState.EndAttack();
	}

	public void EndSkillAttack()
	{
		//playerStateMachine.skillState.EndSkillAttack(); //구현 해야 함.
	}
	#endregion
}
