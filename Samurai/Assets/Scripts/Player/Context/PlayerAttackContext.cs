using UnityEngine;

public class PlayerAttackContext
{
    public PlayerStatusEntity StatusEntity { get; private set; }
    public PlayerMoveUseCase MoveUseCase { get; private set; }
    public PlayerColliderUseCase ColliderUseCase { get; private set; }
    public PlayerAttackContext(PlayerStatusEntity statusEntity,PlayerMoveUseCase moveUseCase,
        PlayerColliderUseCase colliderUseCase)
    {
        StatusEntity = statusEntity;
        MoveUseCase = moveUseCase;
        ColliderUseCase = colliderUseCase;
    }
}
