public class PlayerIdleContext
{
    public PlayerStatusEntity StatusEntity { get; private set; }
    public PlayerInputEntity InputEntity { get; private set; }

    public PlayerIdleContext(PlayerStatusEntity statusEntity,PlayerInputEntity inputEntity)
    {
        StatusEntity = statusEntity;
        InputEntity = inputEntity;
    }
}
