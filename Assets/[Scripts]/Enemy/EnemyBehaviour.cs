using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AI_STATES
{
    IDLE,
    PATROL,
    SEEK,
    ATTACK,
    FLEE
}

public class EnemyBehaviour : MonoBehaviour
{

    private Patrol _patrol;
    private Animator _animator;

    private AI_STATES currentState = AI_STATES.IDLE;

    private float timer = 0f;

    [Header("Animation")]
    public readonly int IsPatrolling = Animator.StringToHash("IsPatrolling");

    // Start is called before the first frame update
    void Start()
    {
        _patrol = GetComponent<Patrol>();
        _animator = GetComponent<Animator>();
        _patrol.isPatrolling = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Every 5 seconds stop patrolling
        if (Time.time - timer > 5f)
        {
            timer = Time.time;
            _patrol.isPatrolling = !_patrol.isPatrolling;

            if (_patrol.isPatrolling)
            {
                _animator.SetBool(IsPatrolling,true);
            }
            else
            {
                _animator.SetBool(IsPatrolling, false);
            }

        }
    }
}
