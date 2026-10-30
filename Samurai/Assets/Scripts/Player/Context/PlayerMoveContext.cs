public class PlayerMoveContext
{
    public PlayerStatusEntity StatusEntity { get; private set; }
    public PlayerInputEntity InputEntity { get; private set; }
    public PlayerCameraEntity CameraEntity { get; private set; }
    public PlayerMoveUseCase MoveUseCase { get; private set; }
    public PlayerCameraUseCase CameraUseCase { get; private set; }
    public PlayerAnimationUseCase AnimationUseCase { get; private set; }
    public PlayerGroundUseCase GroundUseCase { get; private set; }

    public PlayerMoveContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerMoveUseCase moveUseCase,PlayerCameraUseCase cameraUseCase, 
        PlayerAnimationUseCase animationUseCase,PlayerGroundUseCase groundUseCase)
    {
        StatusEntity = statusEntity;
        InputEntity = inputEntity;
        MoveUseCase = moveUseCase;
        CameraUseCase = cameraUseCase;
        AnimationUseCase = animationUseCase;
        GroundUseCase = groundUseCase;
    }
}
