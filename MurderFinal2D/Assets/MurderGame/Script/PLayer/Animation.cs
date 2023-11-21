using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animation : MonoBehaviour
{


    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void CutAttack()
    {
        _animator.Play(Config.CutSword);
    }

    public void StrikeAttack()
    {
        _animator.Play(Config.StringAttack);
    }

    public void Walk()
    {
        _animator.Play(Config.Walk);
    }

    public void WalkSword()
    {
        _animator.Play(Config.WalkSword);
    }

    public void Jump()
    {
        _animator.Play(Config.Jump);
    }

    public void JumpSword()
    {
        _animator.Play(Config.JumpSword);
    }


}
