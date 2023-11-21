using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput: MonoBehaviour
{
    [SerializeField] private MovePlayer _movePlayer;
    [SerializeField] private Animation _animation;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private JumpPlayer _jumpPlayer;

    private void Update()
    {
        RotateInput();
        AttackInput();
        Walk();
    }

    public void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.F) )
        {
            _animation.CutAttack();
            _playerAttack.Attack();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _animation.StrikeAttack();
            _playerAttack.Attack();
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
            _animation.Jump();
            _jumpPlayer.Jump();
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
                _animation.Walk();
            }
        }
    }
}
