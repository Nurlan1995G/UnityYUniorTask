using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Start()
    {
        transform.position = new Vector3(_target.position.x,_target.position.y,transform.position.z);
    }

    private void Update()
    {
        Vector3 position = _target.position;
        position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
    }
}
