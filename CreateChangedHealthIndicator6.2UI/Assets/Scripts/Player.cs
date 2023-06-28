using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _currentHealth;

    private float _maxHealth = 100;
    private float _value = 10;

    public event UnityAction<float> HealthChanged;

    public void TakeDamage()
    {
        if(_currentHealth > 0)
            _currentHealth -= _value;

        HealthChanged?.Invoke(_currentHealth);
    }

    public void TakeHeal()
    { 
        if(_currentHealth < _maxHealth)
            _currentHealth += _value;

        HealthChanged?.Invoke(_currentHealth);
    }
}
