using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Transform _target;

    private void Update()
    {
        MoveEnemy();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void MoveEnemy()
    {
        if (_target == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void Rotate()
    {

    }
}
