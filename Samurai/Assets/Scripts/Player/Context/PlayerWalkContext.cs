public class PlayerWalkContext
{
    public PlayerStatusEntity StatusEntity;
    public PlayerInputEntity InputEntity;
    public PlayerMoveUseCase MoveUseCase;

    public PlayerWalkContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity,
        PlayerMoveUseCase moveUseCase)
    {
        StatusEntity = statusEntity;
        InputEntity = inputEntity;
        MoveUseCase = moveUseCase;
    }
}
