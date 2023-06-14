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
        SetAlarm();
    }

    private void SetAlarm()
    {
        if (_isReached)
            _pathRunningTime += Time.deltaTime;
        else
            _pathRunningTime -= Time.deltaTime; 

        Source();
    }

    private void Source()
    {
        _audioSource.volume = _pathRunningTime / _increaseTimeVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm?.Invoke();
            _isReached = true;
            Debug.Log("В дом кто-то проник, сирена включилась!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isReached = false;
        Debug.Log("В доме больше нет никого!");
    }
}
