using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;

    private Rigidbody2D _rigidbody2D;

    [SerializeField] private PlayerAnimationController _controller;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    public void Walk(float horizontal)
    {
        _rigidbody2D.velocity = new Vector2(horizontal * _speed, _rigidbody2D.velocity.y);
    }

    public void Jump(Vector2 vector2)
    {
        _rigidbody2D.AddForce(vector2 * _jump, ForceMode2D.Impulse);
    }

    public void Rotate(Vector3 vector)
    {
        transform.localRotation = Quaternion.Euler(vector);
    }
}
