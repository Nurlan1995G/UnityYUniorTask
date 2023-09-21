using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class PlayerAnimationController : MonoBehaviour
{
    protected Animator Animator;

    [SerializeField] protected bool _isSword = false;
    [SerializeField] protected bool _isAttack = false;

    public const string Horizontal = "Horizontal";
    public const string Idle = "Idle";
    public const string Walk = "Walk";
    public const string Jump = "Jump";
    public const string JumpSword = "JumpSword";
    public const string AttackSword = "AttackSword";
    public const string StringAttack = "StrikeAttack";

    protected string Num = "Nurlan";

    private void Update()
    {
        
    }

    protected void EnableAttackAnimation(bool isAttack)
    {
        _isAttack = isAttack;
    }

    protected void EnableSwordAnimation(bool sword)
    {
        _isSword = sword;
    }

    protected void AttackAnimation(string anim,bool isAttack)
    {
        Animator.SetBool(anim, isAttack);
    }

    protected void SelectAnimation()
    {
        if (!_isSword)
            WalkAnimation();
        else
            WalkToSwordAnim();
    }

    private void WalkAnimation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Animator.Play(Jump);
        }
        else
        {
            if (Input.GetAxis(Horizontal) == 0)
            {
                Animator.Play(Idle);
            }
            else
            {
                Animator.Play(Walk);
            }
        }
    }

    private void WalkToSwordAnim()
    {
        Animator.SetBool("HaveSword", _isSword);

        if (Input.GetKeyDown(KeyCode.Space))
            Animator.Play(JumpSword);

        if (Input.GetAxis(Horizontal) == 0)
        {
            Animator.SetBool(("RunSword"), false);
        }
        else
        {
            Animator.SetBool(("RunSword"), true);
        }
    }
}
