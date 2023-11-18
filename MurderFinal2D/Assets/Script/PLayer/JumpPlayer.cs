using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool _isGround = true;

    [SerializeField] private float _rayDistance;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position,Vector3.down *  _rayDistance,Color.blue);
    }

    private void FixedUpdate()
    {
        Vector2 originPosition = transform.position;
        Vector2 direction = Vector2.down;
        int layerMask = LayerMask.GetMask("Ground");

        RaycastHit2D hit = Physics2D.Raycast(originPosition,direction,_rayDistance,layerMask);

        _isGround = hit.collider != null;
    }
}
