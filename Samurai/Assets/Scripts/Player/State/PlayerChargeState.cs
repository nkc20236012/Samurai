using UnityEngine;

public class PlayerChargeState : PlayerStateBase
{
    private PlayerMoveUseCase _moveUseCase;
    private float _stateTime;
    public PlayerChargeState(PlayerWalkContext walkContext,PlayerStateData stateData,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _moveUseCase = walkContext.MoveUseCase;
        _stateTime = stateData.ChargeStateEnd;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _moveUseCase.Charge();
    }

    public override void Update()
    {
        base.Update();
        if(GetStateFrame() >= _stateTime)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Boost);
        }
    }
}
