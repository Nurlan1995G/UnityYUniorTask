using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;
    private const string CelebrationEnemy = "Celebration";
    private const string CelebrationNinja = "CelebrationNinja";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if(gameObject.tag == "Minotaur")
            _animator.Play(CelebrationEnemy);
        if (gameObject.tag == "Ninja")
            _animator.Play(CelebrationNinja);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
