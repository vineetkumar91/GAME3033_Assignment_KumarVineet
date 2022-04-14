using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieComponent : MonoBehaviour
{
    public float zombieDamage = 5f;

    public NavMeshAgent zombieNavMesh;
    public Animator zombieAnimator;
    public ZombieStateMachine zombieStateMachine;
    public GameObject followTarget;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        zombieNavMesh = GetComponent<NavMeshAgent>();
        zombieStateMachine = GetComponent<ZombieStateMachine>();

        Initialize(followTarget);
    }

    public void Initialize(GameObject _followTarget)
    {
        followTarget = _followTarget;

        ZombieIdleState idleState = new ZombieIdleState(this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.IDLING, idleState);

        ZombieFollowState followState = new ZombieFollowState(followTarget,this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.FOLLOWING, followState);

        ZombieAttackState attackState = new ZombieAttackState(followTarget, this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.ATTACKING, attackState);

        ZombieDeadState deadState = new ZombieDeadState(this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.IS_DEAD, deadState);

        zombieStateMachine.Initialize(ZombieStateType.FOLLOWING);
    }
}
