public class PlayerWalkContext
{
    public PlayerStatusEntity StatusEntity;
    public PlayerInputEntity InputEntity;
    public PlayerCameraEntity CameraEntity;
    public PlayerMoveUseCase MoveUseCase;

    public PlayerWalkContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerCameraEntity cameraEntity,PlayerMoveUseCase moveUseCase)
    {
        StatusEntity = statusEntity;
        InputEntity = inputEntity;
        CameraEntity = cameraEntity;
        MoveUseCase = moveUseCase;
    }
}
