using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : PlayerAnimationController
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;

    private Rigidbody2D _rigidbody2D;

    private PlayerAnimationController controller;

    private const string Horizontal = "Horizontal";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        controller = GetComponent<PlayerAnimationController>();
    }

    private void Update()
    {
        Rotate();

        SelectAnimation();

        FixedUpdate();  
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis(Horizontal) * _speed, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _jump, ForceMode2D.Impulse);
        }
    }


    protected void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.D))
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.A))
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
