using System;
using UnityEngine;

public class AggressiveDistance : MonoBehaviour
{
    [SerializeField] private float _agroDistance;
    [SerializeField] private Player _target;

    private float _distanceToTarget;

    public event Action AgroToTarget;

    private void Update()
    {
        CheckDistanceToTarget();
    }

    public void CheckDistanceToTarget()
    {
        DistanceToTarget();

        if (_distanceToTarget < _agroDistance)
        {
            AgroToTarget?.Invoke();
        }
        else
            return;
    }

    private void DistanceToTarget()
    {
        _distanceToTarget = Vector2.Distance(transform.position, _target.transform.position);
    }
}
