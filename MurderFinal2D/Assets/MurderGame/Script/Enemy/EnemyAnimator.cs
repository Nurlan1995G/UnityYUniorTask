using UnityEngine;

[RequireComponent(typeof(Animator))]  
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void WalkingAnimation()
    {
        _animator.Play(Config.RunEnemy);
    }

    public void AttackAnimation()
    {
        _animator.Play(Config.AttackEnemy);
    }

    public void DeathAnimation()
    {
        _animator.Play(Config.DeathEnemy);
    }
}
