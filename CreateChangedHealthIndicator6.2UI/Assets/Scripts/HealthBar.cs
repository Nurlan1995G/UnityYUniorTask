using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _player.HealthChanged += OnChangedHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangedHealth;
    }

    private void OnChangedHealth(float target)
    {
        target = target / 100; 

        StartCoroutine(Create(target));
    }

    private IEnumerator Create(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
