using UnityEngine;

public class PlayerStateBase : IPlayerStateChangeable
{
    private PlayerStateMachine _stateMachine;
    private FrameTrigger _startTrigger = new FrameTrigger();
    private FrameTrigger _endTrigger = new FrameTrigger();
    private FrameTrigger _actonTrigger = new FrameTrigger();

    public PlayerStateBase(PlayerStateMachine stateMachine)
    {
        this._stateMachine = stateMachine;
    }

    public PlayerStateMachine GetStateMachine() => _stateMachine;
    public float GetStateFrame() => StateFrame;
    public FrameTrigger GetStartTrigger() => _startTrigger;
    public FrameTrigger GetEndTrigger() => _endTrigger;
    public FrameTrigger GetActionTrigger() => _actonTrigger;
    public float StateFrame { get; private set; }

    public void ResetTrigger()
    {
        _startTrigger.Reset();
        _endTrigger.Reset();
        _actonTrigger.Reset();
    }
    public virtual void Enter()
    {
    }
    public virtual void Update()
    {
        StateFrame++;
    }
    public virtual void FixedUpdate() { }
    public virtual void Exit()
    {
        StateFrame = 0;
        ResetTrigger();
    }

}
