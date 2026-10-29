using UnityEngine;

public class PlayerWalkState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerCameraUseCase _cameraUseCase;

    public PlayerWalkState(PlayerWalkContext walkContext,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = walkContext.StatusEntity;
        _inputEntity = walkContext.InputEntity;
        _moveUseCase = walkContext.MoveUseCase;
        _cameraUseCase = walkContext.CameraUseCase;
    }

    public override void Enter()
    {
        base.Enter();
        _statusEntity.ChangeWalkSpeed();
        _cameraUseCase.WalkMode();
    }

    public override void Exit()
    {
        base.Exit();
        _moveUseCase.Stop();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _moveUseCase.Walk();
    }

    public override void Update()
    {
        base.Update();
        if(_inputEntity.MoveInput.magnitude <= 0)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Idle);
        }
        if (_inputEntity.IsSprint)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Charge);
        }
    }
}
