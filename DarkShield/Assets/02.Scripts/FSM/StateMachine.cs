using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState CurState { get; private set; }

    public IdleState idleState;
    public WalkState walkState;
    public AttackState attackState;
    public DashState dashState;

    public event Action<IState> StateChanged;

    public StateMachine(Player player)
    {
        idleState = new IdleState(player);
        walkState = new WalkState(player);
        attackState = new AttackState(player);
        dashState = new DashState(player);
    }

    //On Start, IdleState
    public void Init(IState state)
    {
        CurState = state;
        state.OnEnter();

        StateChanged?.Invoke(state);
    }

    public void TransitionTo(IState nextState)
    {
        CurState.OnExit();
        CurState = nextState;
        nextState.OnEnter();

        StateChanged?.Invoke(nextState);
    }

    public void OnUpdate()
    {
        if (CurState != null)
        {
            CurState.OnUpdate();
        }
    }
}
