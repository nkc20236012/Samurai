using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerStateData _stateData;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerCameraUseCase _cameraUseCase;
    private PlayerColliderUseCase _colliderUseCase;
    private PlayerAnimationUseCase _animationUseCase;
    private PlayerGroundUseCase _groundUseCase;

    public PlayerAttackState(PlayerAttackContext attackContext,PlayerStateData stateData,
        PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = attackContext.StatusEntity;
        _moveUseCase = attackContext.MoveUseCase;
        _cameraUseCase = attackContext.CameraUseCase;
        _colliderUseCase = attackContext.ColliderUseCase;
        _animationUseCase = attackContext.AnimationUseCase;
        _groundUseCase = attackContext.GroundUseCase;
        _stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        _animationUseCase.StartAnime(StateType.Attack);
        _moveUseCase.Attack();
        _cameraUseCase.BoostMode();
    }

    public override void Exit()
    {
        base.Exit();
        _animationUseCase.EndAnime(StateType.Attack);
        _cameraUseCase.WalkMode();
        _moveUseCase.Reset();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if(GetStartTrigger().Passed(GetStateFrame(),_stateData.AttackTime))
        {
            _colliderUseCase.AttackStart();
        }
        if (GetEndTrigger().Passed(GetStateFrame(), _stateData.AttackTimeEnd))
        {
            _colliderUseCase.AttackEnd();
        }
    }

    public override void Update()
    {
        base.Update();
        if (_stateData.AttackStateEnd <= GetStateFrame())
        {
            if (!_groundUseCase.GroundCheck())
            {
                (this as IPlayerStateChangeable).ChangeState(StateType.Air);
                return;
            }
            (this as IPlayerStateChangeable).ChangeState(StateType.Idle);
            return;
        }
    }
}
