using UnityEngine;

public class MoveStateTestEnemy : StateTest
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        EnemyAnimator.WalkingAnimation();
        transform.position = Vector2.MoveTowards(transform.position,Target.transform.position, _speed * Time.deltaTime);
    }
}
