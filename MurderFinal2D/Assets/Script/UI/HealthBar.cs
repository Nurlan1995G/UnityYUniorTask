using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private PlayerAttack _player;

    private void OnEnable()
    {
        //_player.HealthChanched += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        //_player.HealthChanched -= OnValueChanged;   
    }
}
