using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         Debug.Log("� ���� ���-�� ������!");
        _alarm.PlaySound(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         Debug.Log("� ���� ������ ��� ������!");
        _alarm.StopSound(collision);
    }
}
