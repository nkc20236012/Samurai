public class PlayerBaseContext
{
    public PlayerIdleContext IdleContext {  get;private set; }
    public PlayerMoveContext MoveContext { get; private set; }
    public PlayerAttackContext AttackContext { get; private set; }

    public PlayerBaseContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerCameraEntity cameraEntity,PlayerMoveUseCase moveUseCase,PlayerCameraUseCase cameraUseCase,
        PlayerColliderUseCase colliderUseCase,PlayerAnimationUseCase animationUseCase,
        PlayerGroundUseCase groundUseCase)
    {
        IdleContext = new PlayerIdleContext(statusEntity, inputEntity,moveUseCase,animationUseCase,
            groundUseCase);
        MoveContext = new PlayerMoveContext(statusEntity, inputEntity,moveUseCase,cameraUseCase,
            animationUseCase,groundUseCase);
        AttackContext = new PlayerAttackContext(statusEntity,moveUseCase,cameraUseCase,
            colliderUseCase,animationUseCase,groundUseCase);
    }
}
