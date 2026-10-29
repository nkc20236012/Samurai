public class PlayerWalkContext
{
    public PlayerStatusEntity StatusEntity { get; private set; }
    public PlayerInputEntity InputEntity { get; private set; }
    public PlayerCameraEntity CameraEntity { get; private set; }
    public PlayerMoveUseCase MoveUseCase { get; private set; }
    public PlayerCameraUseCase CameraUseCase { get; private set; }

    public PlayerWalkContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerMoveUseCase moveUseCase,PlayerCameraUseCase cameraUseCase)
    {
        StatusEntity = statusEntity;
        InputEntity = inputEntity;
        MoveUseCase = moveUseCase;
        CameraUseCase = cameraUseCase;
    }
}
