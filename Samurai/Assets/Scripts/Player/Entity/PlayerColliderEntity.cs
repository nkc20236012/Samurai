using UnityEngine;

public class PlayerColliderEntity
{
    public CapsuleCollider PlayerHit {  get; private set; }
    public BoxCollider PlayerAttack { get; private set; }
    public PlayerColliderEntity(CapsuleCollider hit,BoxCollider attack)
    {
        PlayerHit = hit;
        PlayerAttack = attack;
    }
}
