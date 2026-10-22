using UnityEngine;

public class PlayerBoostState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;

    public PlayerBoostState(PlayerWalkContext walkContext,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = walkContext.StatusEntity;
        _inputEntity = walkContext.InputEntity;
        _moveUseCase = walkContext.MoveUseCase;
    }

    public override void Enter()
    {
        base.Enter();
        _moveUseCase.QuickRotate();
        _statusEntity.SprintMode();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _moveUseCase.Boost();
    }

    public override void Update()
    {
        base.Update();
        if(!_inputEntity.IsSprint)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Idle);
        }
    }
}
