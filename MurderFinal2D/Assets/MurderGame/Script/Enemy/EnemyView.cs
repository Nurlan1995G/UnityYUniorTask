using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]  
public class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _enemyAnimation;
    [SerializeField] private EnemyTestMashineState _mashineState;

    private PlayerView _target;

    public PlayerView Target => _target;
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

    public void SetTarget(PlayerView target) 
    {
        _target = target;
        _mashineState.enabled = true;
    }

    public void TakeDamage(int damage) => Health.TakeDamage(damage);

    private void OnDead()
    {
        _enemyAnimation.DeathAnimation();
        Destroy(gameObject);
    }
}
