using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    private EnemyView _enemy;

    public bool IsAttacking { get; private set; }

    public void Attack()
    {
        if (IsAttacking)
            _enemy.TakeDamage(_damage);
    }

    public void SetEnemy(EnemyView enemy)
    {
        _enemy = enemy;
    }
}
