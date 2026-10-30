public class PlayerIdleContext
{
    public PlayerStatusEntity StatusEntity { get; private set; }
    public PlayerInputEntity InputEntity { get; private set; }
    public PlayerMoveUseCase MoveUseCase { get; private set; }
    public PlayerAnimationUseCase AnimationUseCase { get; private set; }
    public PlayerGroundUseCase GroundUseCase { get; private set; }

    public PlayerIdleContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerMoveUseCase moveUseCase,PlayerAnimationUseCase animationUseCase,
        PlayerGroundUseCase groundUseCase)
    {
        StatusEntity = statusEntity;
        InputEntity = inputEntity;
        MoveUseCase = moveUseCase;
        AnimationUseCase = animationUseCase;
        GroundUseCase = groundUseCase;
    }
}
