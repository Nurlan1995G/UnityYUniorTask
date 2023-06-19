using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _jumpHeight;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private const string State = "State";
    private const string Horizontal = "Horizontal";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        int operationIdle = 1;
        int operationRun = 2;

        Rotate();

        if (Input.GetAxis(Horizontal) == 0)
        {
            _animator.SetInteger(State, operationIdle);
        }
        else
        {
            _animator.SetInteger(State, operationRun);
        }

        FixedUpdate();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis(Horizontal) * _speed, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Force);
    }

    private void Rotate()
    {
        int rotateLeft = 180;

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, rotateLeft, 0);
        }
    }
}
