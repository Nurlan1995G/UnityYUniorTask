using UnityEngine;

public class EnemyTestMashineState : MonoBehaviour
{
    [SerializeField] private StateTest _firstState;

    private Player _target;
    private StateTest _currentState;

    private void Start()
    {
        _target = GetComponent<EnemyTest>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        StateTest nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(StateTest startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(StateTest nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if(_currentState != null )
            _currentState.Enter(_target);   
    }
}
