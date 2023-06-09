using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.CountEnemyChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _spawner.CountEnemyChanged -= OnValueChanged;
    }
}
