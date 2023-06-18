using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMony : MonoBehaviour
{
    [SerializeField] private Money _template;
    [SerializeField] private Transform _path;
    [SerializeField] private float _spawnTime;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnTime);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_template, _points[i].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
