using UnityEngine;

public class PlayerAttackContext
{
    public PlayerStatusEntity StatusEntity { get; private set; }
    public PlayerMoveUseCase MoveUseCase { get; private set; }
    public PlayerCameraUseCase CameraUseCase { get; private set; }
    public PlayerColliderUseCase ColliderUseCase { get; private set; }
    public PlayerAnimationUseCase AnimationUseCase { get; private set; }
    public PlayerGroundUseCase GroundUseCase { get; private set; }

    public PlayerAttackContext(PlayerStatusEntity statusEntity,PlayerMoveUseCase moveUseCase,
        PlayerCameraUseCase cameraUseCase,PlayerColliderUseCase colliderUseCase,
        PlayerAnimationUseCase animationUseCase,PlayerGroundUseCase groundUseCase)
    {
        StatusEntity = statusEntity;
        MoveUseCase = moveUseCase;
        CameraUseCase = cameraUseCase;
        ColliderUseCase = colliderUseCase;
        AnimationUseCase = animationUseCase;
        GroundUseCase = groundUseCase;
    }
}
