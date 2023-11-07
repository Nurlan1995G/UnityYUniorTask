using System;
using System.Collections;
using UnityEngine;

public class AttackEnemyState : Heal,IDamageble
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay = 2f;

    private EnemyController _enemy;

    private int _currentHealth;

    public bool IsDeath => _currentHealth < 0;

    public event Action<int, int> EnemyHealthChanged;


    private void Start()
    {
        _currentHealth = Health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        EnemyHealthChanged?.Invoke(_currentHealth, Health);

        if(_currentHealth <= 0 && IsDeath)
        {
            _enemy.Death();
        }
    }

    public void SetEnemy(EnemyController controller)
    {
        _enemy = controller;
    }

    public void Attack()
    {
        if (Time.time >= _delay)
        {
            _enemy.AttackAnimation();
            TakeDamage(_damage);
            print("Нанес удар");
            StartCoroutine(AttackingDelay());
        }
    }

    private IEnumerator AttackingDelay()
    {
        yield return new WaitForSeconds(_delay);
    }
}
