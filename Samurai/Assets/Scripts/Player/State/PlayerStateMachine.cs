using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerStateBase CurrentState;

    private Dictionary<StateType, PlayerStateBase> _stateDic = new Dictionary<StateType, PlayerStateBase>();
    public Dictionary<StateType, PlayerStateBase> StateDic => _stateDic;

    public PlayerStateMachine(PlayerBaseContext baseContext,PlayerStateData stateData)
    {
        _stateDic.Add(StateType.Idle, new PlayerIdleState(baseContext.IdleContext,this));
        _stateDic.Add(StateType.Walk, new PlayerWalkState(baseContext.MoveContext,this));
        _stateDic.Add(StateType.Air, new PlayerAirState(baseContext.MoveContext, this));
        _stateDic.Add(StateType.Charge, new PlayerChargeState(baseContext.MoveContext,stateData,this));
        _stateDic.Add(StateType.Boost, new PlayerBoostState(baseContext.MoveContext,stateData, this));
        _stateDic.Add(StateType.Attack, new PlayerAttackState(baseContext.AttackContext,stateData,this));
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
