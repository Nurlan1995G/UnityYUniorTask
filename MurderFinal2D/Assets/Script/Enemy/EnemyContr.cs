using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyContr : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _agroDistance;
    [SerializeField] private float _attackDistanceTarget;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    [SerializeField] private PlayerAttack _target;

    [SerializeField] private float _attackCoolDown = 2f;

    private int _currentHealth;

    private bool _isAttacking = false;
    private bool _isDeath = false;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private const string IdleEnemy = "IdleEnemy";
    private const string AttackEnemy = "AttackEnemy";
    private const string RunEnemy = "RunEnemy";
    private const string DeathEnemy = "DeathEnemy";

    public event UnityAction<EnemyContr> Dying;
    public event UnityAction<int, int> HealthChangedEnemy;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentHealth = _health;
    }

    private void Update()
    {
        if (!_isDeath)
        {
            float distanceToTarget = Vector2.Distance(transform.position, _target.transform.position);

            if (!_isAttacking)
            {
                if (distanceToTarget < _attackDistanceTarget)
                {
                    StartAttacking();
                }
                else if (distanceToTarget < _agroDistance)
                {
                    _animator.Play(RunEnemy);
                    StartHunding();
                }
                else
                {
                    StopAttacking();
                }
            }
        }
        else
        {
            Death();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChangedEnemy?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0 && !_isDeath)
        {
            _isDeath = true;
            Dying?.Invoke(this);

            StopAttacking();
            StopHunding();

            //Destroy(gameObject);
        }
    }

    private void Death()
    {
        if( _isDeath)
        {
            _animator.Play(DeathEnemy);
        }
    }

    public void OnDeathAnimationEnd()
    {
        StartCoroutine(DeactivateAfterDeathAnimation());
    }

    private IEnumerator DeactivateAfterDeathAnimation()
    {
        gameObject.SetActive(false);
        yield return null;
    }

    private void StartAttacking()
    {
        _isAttacking = true;
        StopHunding();
        _animator.Play(AttackEnemy);
        AttackTarget();
    }

    private void StopAttacking() 
    {
        _isAttacking = false;
        _animator.Play(IdleEnemy);
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(_attackCoolDown);

        _isAttacking = false;
    }

    private void AttackTarget()
    {
        if (Time.time >= _attackCoolDown)
        {
            StartCoroutine(ResetAttack());

            _target.ApplyDamage(_damage);
        }
    }

    private void StartHunding()
    {
        if (_target.transform.position.x < transform.position.x)
        {
            Move(-_speed);
            Rotate(0);
        }
        else if (_target.transform.position.x > transform.position.x)
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
}
