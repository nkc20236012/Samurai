public class PlayerBaseContext
{
    public PlayerIdleContext IdleContext {  get;private set; }
    public PlayerWalkContext WalkContext { get; private set; }
    public PlayerAttackContext AttackContext { get; private set; }

    public PlayerBaseContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerCameraEntity cameraEntity,PlayerMoveUseCase moveUseCase,PlayerCameraUseCase cameraUseCase,
        PlayerColliderUseCase colliderUseCase)
    {
        IdleContext = new PlayerIdleContext(statusEntity, inputEntity);
        WalkContext = new PlayerWalkContext(statusEntity, inputEntity,moveUseCase,cameraUseCase);
        AttackContext = new PlayerAttackContext(statusEntity,moveUseCase,colliderUseCase);
    }
}
