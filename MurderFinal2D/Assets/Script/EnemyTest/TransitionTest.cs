using UnityEngine;

public abstract class TransitionTest : MonoBehaviour
{
    [SerializeField] private StateTest _targetState;

    protected Player Target { get; private set; }
    public bool NeedTransit { get; protected set; }
    public StateTest TargetState => _targetState;

    public void SetTarget(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
