using System;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public event Action AttackReached;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerAttack target))
        {
            print("Соприкосновение колайдера произошло");
            AttackReached?.Invoke();
        }
    }
}
