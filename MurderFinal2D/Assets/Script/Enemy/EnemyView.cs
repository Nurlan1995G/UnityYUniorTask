using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]  
public class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _enemyAnimation;

    public Health Health { get; private set; }

    private void OnValidate()
    {
        if(_enemyAnimation == null)
            _enemyAnimation = GetComponent<EnemyAnimator>();
    }

    private void Awake()
    {
        Health = new Health();
    }

    private void OnEnable()
    {
        Health.Dead += OnDead;
    }

    private void OnDisable()
    {
        Health.Dead -= OnDead;
    }

    public void TakeDamage(int damage) => Health.TakeDamage(damage);

    public void Heal(int valueHeal) => Health.Heal(valueHeal);

    private void OnDead()
    {
        _enemyAnimation.DeathAnimation();
        Destroy(gameObject);
    }
}
