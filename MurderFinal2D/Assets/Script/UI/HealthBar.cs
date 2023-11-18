using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private EnemyView _enemy;
    [SerializeField] private Slider _slider;

    private Health _health;

    private void OnValidate()
    {
        if( _enemy == null)
            _enemy = GetComponentInParent<EnemyView>();
    }

    private void Awake()
    {
        _health = _enemy.Health;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _slider.value = currentHealth / maxHealth;
    }
}
