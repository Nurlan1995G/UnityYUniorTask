using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    protected void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime); 
    }
}
