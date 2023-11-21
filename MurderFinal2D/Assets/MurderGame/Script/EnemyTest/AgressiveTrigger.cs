using UnityEngine;
using UnityEngine.UIElements;

public class AgressiveTrigger : MonoBehaviour
{
    [SerializeField] private EnemyView _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerView target))
        {
            if(target != null) 
                _enemy.SetTarget(target);
        }
    }
}
