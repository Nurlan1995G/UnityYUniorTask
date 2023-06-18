using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MoveEnemy
{
    [SerializeField] private Transform _groundDetect;
    
    private bool _moveRight = false;

    private void Update()
    {
        Move();
        RaycastHit2D groundDetect = Physics2D.Raycast(_groundDetect.position, Vector2.down, 1f);

        if (groundDetect.collider == false)
        {
            if (_moveRight)
            { 
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                _moveRight = true;
            }
        }
    }
}
