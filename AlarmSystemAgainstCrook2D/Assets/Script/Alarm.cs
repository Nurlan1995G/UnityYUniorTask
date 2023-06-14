using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm;
    [SerializeField] private float _increaseTimeVolume;

    private AudioSource _audioSource;
    private float _pathRunningTime;   
    private bool _isReached;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        
    }

    private void StartAlarm()
    {
        _pathRunningTime += Time.deltaTime;
        Source();
    }

    private void StopAlarm()
    {
        _pathRunningTime -= Time.deltaTime;
        Source();
    }

    private void Source()
    {
        _audioSource.volume = _pathRunningTime / _increaseTimeVolume;
    }
/*
    private event UnityAction Reached
    {
        add => _alarm.AddListener(value);
        remove => _alarm.RemoveListener(value);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartAlarm();
            _alarm?.Invoke();
            Debug.Log("В дом кто-то проник, сирена включилась!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAlarm();
        Debug.Log("В доме больше нет никого!");
    }
}
