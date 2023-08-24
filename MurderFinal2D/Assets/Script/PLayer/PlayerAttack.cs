using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : PlayerAnimationController
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    private bool _isAttack = false;

    private int _currentHealth;
    private EnemyContr _currentEnemy;

    public event UnityAction<int,int> HealthChanched;

    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && _isAttack)
        {
            AnimationAttack();
            PerformAttack();
        }
        else if(Input.GetKeyDown(KeyCode.R) && _isAttack) 
        {
            AnimationAttack();
            PerformAttack();
        }
        else
        {
            _isAttack = false;
        }
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

    public void AttackPLayer(EnemyContr enemy)
    {
        _currentEnemy = enemy;

        _isAttack = true;

        EnableAttackAnimation(_isAttack);
    }

    private void PerformAttack()
    {
        if(_currentEnemy != null && _isAttack) 
        {
            _currentEnemy.TakeDamage(_damage);
        }
    }

    /*private void CheckPlayer(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyContr enemy))
        {
            _currentEnemy = enemy;
        }

        StartAttack();
    }*/

    /*private void StartAttack()
    {
        if (_currentEnemy != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Animator.SetBool("AttackSword",true);
                _currentEnemy.TakeDamage(_damage);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Animator.SetBool("StrikeAttack", true);
                _currentEnemy.TakeDamage(_damage);
            }
            else
            {
                Animator.SetBool("AttackSword", false);
                Animator.SetBool("StrikeAttack", false);
            }
        }
    }*/
}
