using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI : Weapon
{
    [SerializeField] private int _maxCountBullets;

    private int _currentCountBullets;

    public override void Reload()
    {
        _currentCountBullets = _maxCountBullets;
    }

    public override void Shoot(Transform shootPoint)
    { 
        if(_currentCountBullets > 0)
        {
            Instantiate(Bullet, shootPoint.position,Quaternion.identity);
            ReduceCountOfBullets();
        }
    }

    private void ReduceCountOfBullets()
    {
        _currentCountBullets--;
    }
}
