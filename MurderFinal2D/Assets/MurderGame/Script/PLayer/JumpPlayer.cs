using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _jumpHeight = 5;
    private bool _isGround = true;
    private bool _isTrigger;

    [SerializeField] private float _rayDistance;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position,Vector3.down *  _rayDistance,Color.blue);
    }

    public void Jump()
    {
        Vector2 originPosition = transform.position;
        Vector2 direction = Vector2.down;
        int layerMask = LayerMask.GetMask("Ground");

        RaycastHit2D hit = Physics2D.Raycast(originPosition,direction,_rayDistance,layerMask);

        _isGround = hit.collider != null;

        if (_isGround)
        {
            _isGround = false;

            _rigidbody2D.AddForce(Vector2.up * _jumpHeight,ForceMode2D.Impulse);
        }
    }
}
