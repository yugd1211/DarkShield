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

    public bool isLeftMouseClick;
    public bool isRightMouseClick;

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

        //기본 공격
        if (Input.GetMouseButtonDown(0) == true) isLeftMouseClick = true;
        else isLeftMouseClick = false;

        //스킬 공격
        if (Input.GetMouseButtonDown(1) == true) isRightMouseClick = true;
        else isRightMouseClick = false;

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

    //유니티 이벤트 함수
    public void EndDash()
    {
        playerStateMachine.dashState.EndDash();
    }

    public void EndAttack()
    {
        playerStateMachine.attackState.EndAttack();
    }
}
