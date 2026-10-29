using UnityEngine;

public class PlayerColliderUseCase
{
    private PlayerColliderEntity _colliderEntity;
    public PlayerColliderUseCase(PlayerColliderEntity colliderEntity)
    {
        _colliderEntity = colliderEntity;
    }
    public void AttackStart()
    {
        Debug.Log("Start");
    }
    public void AttackEnd()
    {
        Debug.Log("End");
    }
}
