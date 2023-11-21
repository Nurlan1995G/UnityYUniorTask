using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private PlayerView _player;
    [SerializeField] private Slider _slider;

    private Health _health;

    private void Awake()
    {
        _health = _player.Health;
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
