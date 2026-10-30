using UnityEngine;

public class PlayerChargeState : PlayerStateBase
{
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    private PlayerAnimationUseCase _animationUseCase;
    private float _stateTime;
    public PlayerChargeState(PlayerMoveContext walkContext,PlayerStateData stateData,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _inputEntity = walkContext.InputEntity;
        _moveUseCase = walkContext.MoveUseCase;
        _animationUseCase = walkContext.AnimationUseCase;
        _stateTime = stateData.ChargeStateEnd;
    }

    public override void Enter()
    {
        base.Enter();
        _animationUseCase.StartAnime(StateType.Charge);
        _inputEntity.BoostBlock(true);
        _inputEntity.AttackBlock(true);
    }

    public override void Exit()
    {
        base.Exit();
        _animationUseCase.EndAnime(StateType.Charge);
        _inputEntity.BoostBlock(false);
        _inputEntity.AttackBlock(false);
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
            return;
        }
    }
}
