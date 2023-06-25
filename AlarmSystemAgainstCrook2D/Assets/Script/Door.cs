using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _movementEnter;
    [SerializeField] private UnityEvent _movementLeave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _movementEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _movementLeave.Invoke();    
    }
}
