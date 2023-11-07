using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private MoveEnemyState _mover;
    [SerializeField] private AttackEnemyState _attacker;
    [SerializeField] private AttackTrigger _attackTrigger;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private AgroDistance _agroDistance; 

    [SerializeField] private PlayerAttack _target;

    private void OnEnable()
    {
        _agroDistance.MoverToTarget += OnMoverToTarget;
        _attackTrigger.AttackReached += OnAttackReached;
    }


    private void Start()
    {
        
    }

    private void OnDisable()
    {
        _agroDistance.MoverToTarget -= OnMoverToTarget;
        _attackTrigger.AttackReached -= OnAttackReached;
    }

    public void Death()
    {
        _attacker.SetEnemy(this);
        _enemyAnimation.DeathAnimation();   
        Destroy(gameObject);
    }

    public void AttackAnimation()
    {
        _enemyAnimation.AttackAnimation();
    }

    private void OnMoverToTarget()
    {
        if (_agroDistance.IsMover)
        {
            MoveToTarget();
            _enemyAnimation.WalkingAnimation();
            _mover.MoveEnemy();
        }
    }

    private void MoveToTarget()
    {
        _mover.SetTarget(_target.transform);
    }

    private void OnAttackReached()
    {
        //Ќужно как-то сделать так чтобы MoverEnemyState отключилс€, возможно попробовать через булевые переменные

        _attacker.Attack();
    }
}
