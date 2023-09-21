using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private float _agroDistance;
    [SerializeField] private int _damage;
    [SerializeField] private Transform _target;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Distance();
    }

    private void Distance()
    {
        float distanceToTarget = Vector2.Distance(transform.position, _target.position);

        if (distanceToTarget < _agroDistance)
        {
            _animator.Play("RunGoblin");
            StartHunding();
        }
        else if (distanceToTarget >= _agroDistance)
        {
            _animator.Play("IdleGoblin");
            StopHunding();
        }
    }

    private void StartHunding()
    {
        if (_target.position.x < transform.position.x)
        {
            Move(-_speed);
            Rotate(0);
        }
        else if (_target.position.x > transform.position.x)
        {
            Move(_speed);
            Rotate(180);
        }
    }

    private void Move(float speed)
    {
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }

    private void Rotate(int angle)
    {
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }

    private void StopHunding()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerAttack player))
        {
            _animator.Play("AttackGoblin");
            player.ApplyDamage(_damage);
        }
    }
}
