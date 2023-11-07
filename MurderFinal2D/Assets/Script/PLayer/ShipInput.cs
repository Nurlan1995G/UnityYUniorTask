using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput: MonoBehaviour
{
    [SerializeField] private MovePlayer _movePlayer;
    [SerializeField] private PlayerAnimationController _controller;
    [SerializeField] private PlayerAttack _playerAttack;

    protected bool IsInputRight = false;
    protected bool IsInputLeft = false;
    protected bool IsJump;

    private void Update()
    {
        RotateInput();
        AttackInput();
        JumpInput();
        Walk();
    }

    public void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.F) && _playerAttack.IsAttacking)
        {
            _controller.AttackAnimation(Config.AttackSword, true);
            //_playerAttack.PerformAttack();
        }
        if (Input.GetKeyDown(KeyCode.R) && _playerAttack.IsAttacking)
        {
            _controller.AttackAnimation(Config.StringAttack, true);
        }
        else
        {
            //_controller.AttackAnimation(Config.AttackSword, false);
            //_controller.AttackAnimation(Config.StringAttack, false);
        }
    }

    public void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movePlayer.Jump(Vector2.up);
        }
    }

    public void RotateInput()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _movePlayer.Rotate(Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _movePlayer.Rotate(new Vector3(0,180,0));
        }
    }

    public void Walk()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //_animator.Play(Config.Jump);
            _controller.JumpAnimation();
        }
        else
        {
            if (Input.GetAxis(Config.Horizontal) == 0)
            {
                //_animator.Play(Config.Idle);
            }
            else
            {
                _movePlayer.Walk(Input.GetAxis(Config.Horizontal));
                _controller.WalkAndIdleAnimation(Input.GetAxis(Config.Horizontal));
            }
        }
    }
}
