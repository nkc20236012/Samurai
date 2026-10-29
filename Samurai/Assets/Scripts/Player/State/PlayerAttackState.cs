using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerStateData _stateData;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerColliderUseCase _colliderUseCase;
    public PlayerAttackState(PlayerAttackContext attackContext,PlayerStateData stateData,
        PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = attackContext.StatusEntity;
        _moveUseCase = attackContext.MoveUseCase;
        _colliderUseCase = attackContext.ColliderUseCase;
        _stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        _moveUseCase.Attack();
    }

    public override void Exit()
    {
        base.Exit();
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
        if(_stateData.AttackStateEnd <= GetStateFrame())
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Idle);
        }
    }
}
