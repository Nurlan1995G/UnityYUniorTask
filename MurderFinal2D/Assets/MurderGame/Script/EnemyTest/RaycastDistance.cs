using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RaycastDistance : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private EnemyView _enemy;

    private Rigidbody2D _rigidbody2D;
    private bool _isPlayer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        var direction = Vector2.right;

        Debug.DrawRay(transform.position,-direction *  _rayDistance, Color.yellow);
    }

    private void Update()
    {
        Vector3 direction = Vector2.right;
        Vector3 originPosition = transform.position;
        var layerMask = LayerMask.GetMask("Player");


        RaycastHit2D sphere = Physics2D.CircleCast(originPosition, _rayDistance, Vector2.zero, 0);

       // RaycastHit2D hit = Physics2D.Raycast(originPosition, -direction, _rayDistance,layerMask);

        _isPlayer = sphere.collider != null;

        if(sphere.collider.TryGetComponent(out PlayerView player))
        {
            _enemy.SetTarget(player);
        }
    }
}
