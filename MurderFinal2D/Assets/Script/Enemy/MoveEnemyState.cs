using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyState : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Transform _target;


    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void MoveEnemy()
    {
        if (_target == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position,_target.position, _speed * Time.deltaTime);
    }
    
    public void Rotate()
    {

    }
}
