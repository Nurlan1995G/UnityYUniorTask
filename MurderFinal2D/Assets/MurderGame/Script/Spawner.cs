using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;

    private Wave _currentWave;
    private int _currentNumberWave = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> CountEnemyChanged;

    private void Start()
    {
        SetWave(_currentNumberWave);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= _currentWave.Delay)
        {
            //InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            CountEnemyChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if(_currentWave.Count <= _spawned)
        {
            if(_waves.Count >= _currentNumberWave + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    private void NextWave()
    {
        SetWave(++_currentNumberWave);
        _spawned = 0;
    }

  /* // private void InstantiateEnemy()
    {
        EnemyContr enemy = Instantiate(_currentWave.Template,_spawnPoint.position,_spawnPoint.rotation,_spawnPoint).GetComponent<EnemyContr>();
        enemy.Dying += OnEnemyDying;
    }*/

   /*// private void OnEnemyDying(EnemyContr enemy)
    {
        enemy. -= OnEnemyDying;
    }*/

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        CountEnemyChanged?.Invoke(0, 1);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
