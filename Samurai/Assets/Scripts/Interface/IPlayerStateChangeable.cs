public interface IPlayerStateChangeable : IHasPlayerStateMachine
{
    public void ChangeState(StateType newState)
    {
        PlayerStateBase playerStateBase = GetStateMachine().StateDic[newState];
        GetStateMachine().ChangeState(playerStateBase);
    }
}
