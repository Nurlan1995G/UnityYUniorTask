using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log("Здоровье Goblina - " + _health);

        if(_health <= 0)
        {
            _animator.Play("DeathGoblin");
            StartCoroutine(ResetEnemy());
            gameObject.SetActive(false);
            Debug.Log("Goblin убит");
        }
    }

    private IEnumerator ResetEnemy()
    {
        yield return new WaitForSeconds(2);
    }
}
