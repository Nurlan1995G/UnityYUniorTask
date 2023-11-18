using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RaycastDistance : MonoBehaviour
{
    [SerializeField] private float _rayDistance;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position,Vector3.forward *  _rayDistance, Color.yellow);
    }

    private void Update()
    {
        Vector2 direction = transform.forward;
        Vector2 originPosition = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(originPosition, direction, _rayDistance);

        if(hit.collider.TryGetComponent(out Player player))
        {
            Debug.Log("Произошло касание с игроком Raycat");
        }
    }
}
