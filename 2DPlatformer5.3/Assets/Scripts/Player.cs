using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        int operationIdle = 1;
        int operationRun = 2;

        if (Input.GetKey(KeyCode.None))
        {
            _animator.SetInteger("State", operationIdle);
        }
        else
        {
            Flip();
            _animator.SetInteger("State", operationRun);
        }

        FixedUpdate();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody2D.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.AddForce(transform.up * _jumpHeight, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        int rotationLeft = 180;

        if(Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0,rotationLeft, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            Destroy(collision.gameObject);
        }
    }
}
