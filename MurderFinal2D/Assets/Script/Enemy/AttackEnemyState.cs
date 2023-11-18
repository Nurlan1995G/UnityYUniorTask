using System;
using UnityEngine;

public class AttackEnemyState : IDamageble
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay = 2f;

    private float _lastAttackTime = 0f;

    private EnemyView _enemy;

    private int _currentHealth;

    public bool IsDeath => _currentHealth < 0;
    public bool IsAttacking = false;

    public event Action<int, int> EnemyHealthChanged;
    public event Action EnemyAttackChanged;

    private void Update()
    {
        if (IsAttacking)
        {
            if (_lastAttackTime <= 0)
            {
                Attack();
                _lastAttackTime = _delay;
            }

            _lastAttackTime -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (Time.time >= _delay && IsAttacking)
        {
            EnemyAttackChanged?.Invoke();
            //TakeDamage(_damage);
        }
    }

    public void TakeDamage(int damage)
    {
        
    }
}
