using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public abstract class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] protected Animator Animator;

    [SerializeField] private bool _isSword = false;
    private bool _isAttack = false;

    public const string Horizontal = "Horizontal";
    public const string Idle = "Idle";
    public const string Walk = "Walk";
    public const string Jump = "Jump";
    public const string JumpSword = "JumpSword";

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void EnableSwordAnimation(bool isSword)
    {
        _isSword = isSword;
         Animator.SetBool("HaveSword", _isSword);

        AnimationAttack();
    }

    protected void EnableAttackAnimation(bool isAttack)
    {
        _isAttack = isAttack;

        Debug.Log(_isAttack + "- isAttack - метод EnableAttackAnim");
    }

    protected void AnimationAttack()
    {
        Debug.Log(_isSword + " - AnimationAttack");

        if (_isSword)
        {
            Debug.Log("AnimationAttack");

            if (_isAttack)
            {
                Debug.Log("isAttack - true");

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("Нажал на клавишу F");

                    Animator.SetBool("AttackSword", true);
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    Debug.Log("Нажал на клавишу R");

                    Animator.SetBool("StrikeAttack", true);
                }
                else
                {
                    Animator.SetBool("AttackSword", false);
                    Animator.SetBool("StrikeAttack", false);
                }
            }
        }
    }

    protected void SelectAnimation()
    {
        if (_isSword == false)
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
        else
        {
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
}
