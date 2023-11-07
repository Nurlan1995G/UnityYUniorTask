using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroDistance : MonoBehaviour
{
    [SerializeField] private float _agroDistance;
    [SerializeField] private PlayerAttack _target;

    private float _distanceToTarget;

    public bool IsMover { get;private set; }

    public event Action AgroDistanceTarget;
    public event Action MoverToTarget;

    private void Update()
    {
        CheckDistanceToTarget();
    }

    public void CheckDistanceToTarget()
    {
        DistanceToTarget();

        if (_distanceToTarget < _agroDistance)
        {
            IsMover = true;
            MoverToTarget?.Invoke();
        }
    }

    private void DistanceToTarget()
    {
        _distanceToTarget = Vector2.Distance(transform.position, _target.transform.position);
    }
}
