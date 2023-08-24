using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetect : MonoBehaviour
{
    private PlayerAttack _player;
    private PlayerAnimationController _animationController;

    //[SerializeField] private UnityEvent _portalEnter;
    // [SerializeField] private UnityEvent _enemyEnter;
    // [SerializeField] private UnityEvent _portalLeave;
    // [SerializeField] private UnityEvent _enemyLeave;

    private void Start()
    {
        _player = GetComponent<PlayerAttack>();
        _animationController = GetComponent<PlayerAnimationController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //_portalEnter.Invoke();
       // _enemyEnter.Invoke();
        

        if(collision.TryGetComponent(out Sword sword))
        {
            sword.SetActiveSword(_animationController);
        }

        if(collision.TryGetComponent(out EnemyContr enemy))
        {
            _player.AttackPLayer(enemy);
        }

        if(collision.TryGetComponent(out Portal portal))
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
    }
}
