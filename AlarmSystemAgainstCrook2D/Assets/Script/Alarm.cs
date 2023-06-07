using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm; 
    [SerializeField] private float _increaseTimeVolume;  

    private AudioSource _audioSource;
    private float _pathRunningTime;   //время выполнения пути
    private bool _isReached;  

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
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

    private void Update()
    {
        float path = _pathRunningTime + Time.deltaTime;

    }

    private void Source()
    {
        _audioSource.volume = _pathRunningTime / _increaseTimeVolume;
    }

    private void StartPele(float path)
    {

    }

    private event UnityAction Reached
    {
        add => _alarm.AddListener(value);
        remove => _alarm.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Source();
            _alarm?.Invoke();
            Debug.Log("Сирена сработала. Кто-то проник в дом!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAlarm();
        Debug.Log("В доме нет постаронних!");
    }
}
