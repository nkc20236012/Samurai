public class PlayerStatusEntity
{
    public float Health{ get; private set; }
    public float MoveSpeed { get; private set; }
    public float SprintSpeed { get; private set; }

    public PlayerStatusEntity(PlayerStatus status)
    {
        Health = status.Health;
        MoveSpeed = status.MoveSpeed;
        SprintSpeed = status.SprintSpeed;
    }
}
