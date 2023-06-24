using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]  
public class AlarmDoor : MonoBehaviour
{
    [SerializeField] private float _pathRunningTime;
    [SerializeField] private UnityEvent _alarm;

    private AudioSource _source;
    private float _receivedVolume;
    private Coroutine _coroutine;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _receivedVolume = 1;
        _source.Play();
        WorkCoroutine(collision);
        Debug.Log("В доме ворюга, тварина!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _receivedVolume = 0;
        WorkCoroutine(collision);
        Debug.Log("Свалил сучара!");
    }

    private void WorkCoroutine(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(CreateCoroutine());
        }
    }

    private IEnumerator CreateCoroutine()
    {
        while(_source.volume != _receivedVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, _receivedVolume, _pathRunningTime * Time.deltaTime);
            yield return null;
        }
    }
}
