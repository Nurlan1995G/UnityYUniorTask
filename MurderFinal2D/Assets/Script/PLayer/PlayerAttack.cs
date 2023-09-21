using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : PlayerAnimationController
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    private int _currentHealth;
    protected EnemyContr _currentEnemy;

    private MovePlayer _movePlayer;

    public event UnityAction<int,int> HealthChanched;

    private void Start()
    {
        _currentHealth = _health;
        Animator = GetComponent<Animator>();

        _movePlayer = GetComponent<MovePlayer>();
    }

    private void Update()
    {
        Attack();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanched?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isAttack && _currentEnemy != null)
        {
            AttackAnimation(AttackSword, true);
            PerformAttack();
        }
        else if (Input.GetKeyDown(KeyCode.R) && _isAttack && _currentEnemy != null)
        {
            AttackAnimation(StringAttack, true);
            PerformAttack();
        }
        else
        {
            AttackAnimation(AttackSword, false);
            AttackAnimation(StringAttack, false);
        }
    }

    private void PerformAttack()
    {
        _currentEnemy.TakeDamage(_damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyContr enemy))
        {
            _currentEnemy = enemy;

            if (_isSword)
            {
                _isAttack = true;

                EnableAttackAnimation(_isAttack);
            }
        }

        if (collision.TryGetComponent(out Sword sword))
        {
            sword.SetActiveSword();

            _isSword = true;

            _movePlayer.EnableSword(_isSword);
        }
    }
}
