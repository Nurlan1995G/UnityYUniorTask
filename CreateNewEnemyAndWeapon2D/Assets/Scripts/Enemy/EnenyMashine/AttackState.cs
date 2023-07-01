using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;
    private float _lastAttackTime;

    private const string AttackEnemy = "Attack";
    private const string AttackNinja = "AttackNinja";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        if(gameObject.tag == "Minotaur")
        {
            _animator.Play(AttackEnemy);
            target.ApplyDamage(_damage);
        }

         if(gameObject.tag == "Ninja")
        {
            _animator.Play(AttackNinja);
            target.ApplyDamage(_damage);
        }
    }

    private void SelectAnimation(string animation,Player target)
    {
        _animator.Play(animation);
        target.ApplyDamage(_damage);
    }
}
