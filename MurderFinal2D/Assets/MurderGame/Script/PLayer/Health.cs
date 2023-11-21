using UnityEngine;
using UnityEngine.Events;

public class Health
{
    private int _value;
    private readonly int _minValue = 0;
    private readonly int _maxValue = 100;   

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction Dead;

    public Health()
    {
        _value = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        Mathf.Clamp(_value -= damage, _minValue, _maxValue);
        HealthChanged?.Invoke(_value, _maxValue);

        if(_value == _minValue)
             Dead?.Invoke();
    }

    public void Heal(int valueHeal)
    {
        Mathf.Clamp(_value += valueHeal, _minValue, _maxValue);
        HealthChanged?.Invoke(_value, _maxValue);
    }
}
