using UnityEditorInternal;
using UnityEngine;

public class DistanceTransition : TransitionTest
{
    [SerializeField] private float _transitionRange;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            NeedTransit = true;
    }
}
