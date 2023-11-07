using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private bool _isSword = false;
    private bool _isAttack = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackAnimation(string anim,bool isAttack)
    {
        _animator.SetBool(anim, isAttack);
    }

    public void WalkAndIdleAnimation(float horizontal)
    {
        if(horizontal == 0)
        {
            _animator.Play(Config.Idle);
        }
        else
        {
            _animator.Play(Config.Walk);
        }
    }

    public void JumpAnimation()
    {
         _animator.Play(Config.Jump);
    }

    private void WalkToSwordAnim()
    {
        _animator.SetBool(Config.HaveSword, _isSword);

        if (Input.GetKeyDown(KeyCode.Space))
            _animator.Play(Config.JumpSword);

        if (Input.GetAxis(Config.Horizontal) == 0)
        {
            _animator.SetBool((Config.RunSword), false);
        }
        else
        {
            _animator.SetBool((Config.RunSword), true);
        }
    }
}
