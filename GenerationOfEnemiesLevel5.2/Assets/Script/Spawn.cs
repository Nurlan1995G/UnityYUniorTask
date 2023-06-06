using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _path;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        int spawnTime = 2;

        WaitForSeconds waitForSecond = new WaitForSeconds(spawnTime);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_template, _points[i].position, Quaternion.identity);

            yield return waitForSecond;
        }
    }
}
