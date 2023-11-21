using System;
using UnityEngine;

public class EnemyTest : MonoBehaviour, IDamageble
{
    [SerializeField] private int _health;
    [SerializeField] private EnemyTestMashineState _enemyMashine;

    private PlayerView _target;

    public PlayerView Target => _target;

    public event Action<EnemyTest> Dying;

    public void SetTarget(PlayerView target)
    {
        _target = target;
        _enemyMashine.enabled = true;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
