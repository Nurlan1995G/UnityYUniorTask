using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : IDamageble
{
    private bool _isAttacking = false;
    [SerializeField] private int _damage;

    private EnemyContr _enemy;

    private PlayerAnimationController _controller;

    public bool IsAttacking => _isAttacking;  
    public bool IsSwordAttack { get; private set; }

    public event UnityAction<int> HealthChanched;

    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        
    }

    public void PerformAttack(EnemyContr enemy)
    {
        _enemy.TakeDamage(_damage);
        //enemy.TakeDamage(Damage);
    }

    private EnemyContr CheckEnemy(EnemyContr enemyContr)
    {
        if(enemyContr != null)
        {
            return enemyContr;
        }

        return null;
    }

    private void AttackSword()
    {
        if (IsSwordAttack)
        {
            _isAttacking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyContr enemy))
        {
            CheckEnemy(enemy);

            AttackSword();
        }

        if (collision.TryGetComponent(out Sword sword))
        {
            sword.SetActiveSword();

            if (sword.IsSword == true)
                IsSwordAttack = true;
        }
    }
}
