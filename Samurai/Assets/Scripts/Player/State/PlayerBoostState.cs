using UnityEngine;

public class PlayerBoostState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerCameraUseCase _cameraUseCase;

    public PlayerBoostState(PlayerWalkContext walkContext,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = walkContext.StatusEntity;
        _inputEntity = walkContext.InputEntity;
        _moveUseCase = walkContext.MoveUseCase;
        _cameraUseCase = walkContext.CameraUseCase;
    }

    public override void Enter()
    {
        base.Enter();
        _statusEntity.ChangeBoostSpeed();
        _cameraUseCase.BoostMode();
    }

    public override void Exit()
    {
        base.Exit();
        _moveUseCase.BoostStop();
        _cameraUseCase.WalkMode();
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
        if(_inputEntity.IsAttack)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Attack);
        }
    }
}
