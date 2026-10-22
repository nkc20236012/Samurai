public class PlayerIdleContext
{
    public PlayerStatusEntity StatusEntity;
    public PlayerInputEntity InputEntity;

    public PlayerIdleContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity)
    {
        StatusEntity = statusEntity;
        InputEntity = inputEntity;
    }
}
