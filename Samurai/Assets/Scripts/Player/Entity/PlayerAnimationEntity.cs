using UnityEngine;

public class PlayerAnimationEntity
{
    public Animator PlayerAnimator {  get; private set; }

    public PlayerAnimationEntity(Animator animator)
    {
        PlayerAnimator = animator;
    }
}
