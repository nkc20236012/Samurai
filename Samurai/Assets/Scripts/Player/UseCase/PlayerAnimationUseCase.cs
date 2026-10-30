using UnityEngine;

public class PlayerAnimationUseCase
{
    private Animator _animator;
    public PlayerAnimationUseCase(PlayerAnimationEntity animationEntity)
    {
        _animator = animationEntity.PlayerAnimator;
    }

    public void StartAnime(StateType stateName)
    {
        _animator.SetBool(stateName.ToString(), true);
    }
    public void EndAnime(StateType stateName)
    {
        _animator.SetBool(stateName.ToString(), false);
    }
}
