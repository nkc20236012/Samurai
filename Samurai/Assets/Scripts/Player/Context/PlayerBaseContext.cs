public class PlayerBaseContext
{
    public PlayerIdleContext IdleContext;
    public PlayerWalkContext WalkContext;

    public PlayerBaseContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerCameraEntity cameraEntity,PlayerMoveUseCase moveUseCase)
    {
        IdleContext = new PlayerIdleContext(statusEntity, inputEntity);
        WalkContext = new PlayerWalkContext(statusEntity, inputEntity,moveUseCase);
    }
}
