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
        _colliderEntity.PlayerAttack.enabled = true;
        Debug.Log("Start");
    }
    public void AttackEnd()
    {
        _colliderEntity.PlayerAttack.enabled = false;
        Debug.Log("End");
    }
}
