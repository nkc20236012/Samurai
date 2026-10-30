using UnityEngine;

public class PlayerAirState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerCameraUseCase _cameraUseCase;
    private PlayerAnimationUseCase _animationUseCase;
    private PlayerGroundUseCase _groundUseCase;

    public PlayerAirState(PlayerMoveContext moveContext,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = moveContext.StatusEntity;
        _inputEntity = moveContext.InputEntity;
        _moveUseCase = moveContext.MoveUseCase;
        _cameraUseCase = moveContext.CameraUseCase;
        _animationUseCase = moveContext.AnimationUseCase;
        _groundUseCase = moveContext.GroundUseCase;
    }

    public override void Enter()
    {
        base.Enter();
        _animationUseCase.StartAnime(StateType.Air);
    }

    public override void Exit()
    {
        base.Exit();
        _animationUseCase.EndAnime(StateType.Air);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
        if(_groundUseCase.GroundCheck())
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
