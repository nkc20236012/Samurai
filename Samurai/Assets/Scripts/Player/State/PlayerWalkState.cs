using UnityEngine;

public class PlayerWalkState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerCameraUseCase _cameraUseCase;
    private PlayerAnimationUseCase _animationUseCase;
    private PlayerGroundUseCase _groundUseCase;

    public PlayerWalkState(PlayerMoveContext walkContext,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = walkContext.StatusEntity;
        _inputEntity = walkContext.InputEntity;
        _moveUseCase = walkContext.MoveUseCase;
        _cameraUseCase = walkContext.CameraUseCase;
        _animationUseCase = walkContext.AnimationUseCase;
        _groundUseCase = walkContext.GroundUseCase;
    }

    public override void Enter()
    {
        base.Enter();
        _animationUseCase.StartAnime(StateType.Walk);
        _statusEntity.ChangeWalkSpeed();
        _cameraUseCase.WalkMode();
    }

    public override void Exit()
    {
        base.Exit();
        _animationUseCase.EndAnime(StateType.Walk);
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
        if(!_groundUseCase.GroundCheck())
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Air);
            return;
        }
        if (_inputEntity.MoveInput.magnitude <= 0)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Idle);
            return;
        }
        if (_inputEntity.IsSprint)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Charge);
            return;
        }
    }
}
