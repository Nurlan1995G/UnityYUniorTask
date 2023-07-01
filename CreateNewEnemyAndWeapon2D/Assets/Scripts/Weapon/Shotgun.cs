using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Shotgun : Weapon
{
    private int _maxCountBullets = 10;

    private int _currentCountBullets;

    public override void Reload()
    {
        _currentCountBullets = _maxCountBullets;
    }

    public override void Shoot(Transform shootPoint)
    {
        if (_currentCountBullets > 0)
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
