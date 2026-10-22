using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerStateBase CurrentState;

    private Dictionary<StateType, PlayerStateBase> _stateDic = new Dictionary<StateType, PlayerStateBase>();
    public Dictionary<StateType, PlayerStateBase> StateDic => _stateDic;

    public PlayerStateMachine(PlayerBaseContext baseContext)
    {
        _stateDic.Add(StateType.Idle, new PlayerIdleState(baseContext.IdleContext,this));
        _stateDic.Add(StateType.Walk, new PlayerWalkState(baseContext.WalkContext,this));
        _stateDic.Add(StateType.Boost, new PlayerBoostState(baseContext.WalkContext, this));
    }

    public void Initialize(StateType startState)
    {
        CurrentState = StateDic[startState];
        CurrentState.Enter();
    }
    public void ChangeState(PlayerStateBase newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    public void OnUpdate()
    {
        CurrentState.Update();
    }
    public void OnFixedUpdate()
    {
        CurrentState.FixedUpdate();
    }
}
