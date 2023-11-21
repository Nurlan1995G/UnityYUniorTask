using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateTest : StateTest
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime = 0f;

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        if (Target != null)
        {
            EnemyAnimator.AttackAnimation();
            Target.ApplyDamage(_damage);
        }
    }
}
