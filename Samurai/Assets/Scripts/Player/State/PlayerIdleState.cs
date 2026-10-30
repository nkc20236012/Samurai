using System.Diagnostics;

public class PlayerIdleState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerAnimationUseCase _animationUseCase;
    private PlayerGroundUseCase _groundUseCase;

    public PlayerIdleState(PlayerIdleContext idleContext,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = idleContext.StatusEntity;
        _inputEntity = idleContext.InputEntity;
        _moveUseCase = idleContext.MoveUseCase;
        _animationUseCase = idleContext.AnimationUseCase;
        _groundUseCase = idleContext.GroundUseCase;
    }

    public override void Enter()
    {
        base.Enter();
        _animationUseCase.StartAnime(StateType.Idle);
    }

    public override void Exit()
    {
        base.Exit();
        _animationUseCase.EndAnime(StateType.Idle);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
        if(!_groundUseCase.GroundCheck())
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Air);
            return;
        }
        if (_inputEntity.MoveInput.magnitude != 0)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Walk);
            return;
        }
        if(_inputEntity.IsSprint)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Charge);
            return;
        }
    }
}
