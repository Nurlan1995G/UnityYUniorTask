using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm;
    [SerializeField] private float _pathRunningTime;  

    private int _receivedValue;  
    private Coroutine _coroutine;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }
  
    public void WorkCoroutine(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(CreateCoroutine());
        }
    }

    public void PlaySound(Collider2D collision)
    {
        _receivedValue = 1;
        _audioSource.Play();
        WorkCoroutine(collision);
    }

    public void StopSound(Collider2D collision)
    {
        _receivedValue = 0;
        WorkCoroutine(collision);
    }

    private IEnumerator CreateCoroutine() 
    {
        while(_audioSource.volume != _receivedValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume,_receivedValue,_pathRunningTime * Time.deltaTime);
            yield return null;
        }
    }
}
