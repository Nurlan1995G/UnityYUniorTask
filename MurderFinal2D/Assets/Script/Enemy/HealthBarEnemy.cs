using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : Bar
{
    [SerializeField] private EnemyContr _enemy;

    private void OnEnable()
    {
        //_enemy.HealthChangedEnemy += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        //_enemy.HealthChangedEnemy -= OnValueChanged;
    }
}
