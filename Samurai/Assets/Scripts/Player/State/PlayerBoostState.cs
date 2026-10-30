using UnityEngine;

public class PlayerBoostState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerCameraUseCase _cameraUseCase;
    private PlayerAnimationUseCase _animationUseCase;
    private PlayerGroundUseCase _groundUseCase;
    private PlayerStateData _stateData;
    private bool _isAttack = false;

    public PlayerBoostState(PlayerMoveContext walkContext,PlayerStateData stateData,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = walkContext.StatusEntity;
        _inputEntity = walkContext.InputEntity;
        _moveUseCase = walkContext.MoveUseCase;
        _cameraUseCase = walkContext.CameraUseCase;
        _animationUseCase = walkContext.AnimationUseCase;
        _groundUseCase = walkContext.GroundUseCase;
        _stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        _animationUseCase.StartAnime(StateType.Boost);
        _isAttack = false;
        _statusEntity.ChangeBoostSpeed();
        _cameraUseCase.BoostMode();
    }

    public override void Exit()
    {
        base.Exit();
        _animationUseCase.EndAnime(StateType.Boost);
        if (!_isAttack)
        {
            _moveUseCase.BoostStop();
            _cameraUseCase.WalkMode();
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _moveUseCase.Boost();
    }

    public override void Update()
    {
        base.Update();
        if(_inputEntity.IsAttack)
        {
            _isAttack = true;
            (this as IPlayerStateChangeable).ChangeState(StateType.Attack);
            return;
        }
        if(!_inputEntity.IsSprint)
        {
            if(!_groundUseCase.GroundCheck())
            {
                (this as IPlayerStateChangeable).ChangeState(StateType.Air);
                return;
            }
            (this as IPlayerStateChangeable).ChangeState(StateType.Idle);
            return;
        }
    }
}
