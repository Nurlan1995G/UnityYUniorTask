using UnityEngine;
using UnityEngine.UIElements;

public class AgressiveTrigger : MonoBehaviour
{
    [SerializeField] private EnemyTest _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player target))
        {
            _enemy.SetTarget(target);
        }
    }
}
