using System.Collections.Generic;
using UnityEngine;

public abstract class StateTest : MonoBehaviour
{
    [SerializeField] private List<TransitionTest> _transitions;
    [SerializeField] protected EnemyAnimator EnemyAnimator;

    protected PlayerView Target { get; private set; }

    public void Enter(PlayerView target)
    {
        if (!enabled)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.SetTarget(target);
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled  = false;
        }
    }

    public StateTest GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
