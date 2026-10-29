public class PlayerIdleState : PlayerStateBase
{
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;

    public PlayerIdleState(PlayerIdleContext idleContext,PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _statusEntity = idleContext.StatusEntity;
        _inputEntity = idleContext.InputEntity;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
        if(_inputEntity.MoveInput.magnitude != 0)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Walk);
        }
        if(_inputEntity.IsSprint)
        {
            (this as IPlayerStateChangeable).ChangeState(StateType.Charge);
        }
    }
}
