using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieComponent : MonoBehaviour
{
    public float zombieDamage = -5f;

    public NavMeshAgent zombieNavMesh;
    public Animator zombieAnimator;
    public ZombieStateMachine zombieStateMachine;
    public GameObject followTarget;
    public Rigidbody m_rb;

    public bool isTakingDamage = false;
    private bool executeOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        zombieNavMesh = GetComponent<NavMeshAgent>();
        zombieStateMachine = GetComponent<ZombieStateMachine>();
        m_rb = GetComponent<Rigidbody>();

        followTarget = GameObject.FindGameObjectWithTag("Player");

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

        DisablePhysics();

        zombieStateMachine.Initialize(ZombieStateType.FOLLOWING);
    }


    /// <summary>
    /// Enables physics
    /// </summary>
    public void EnablePhysics()
    {
        zombieNavMesh.enabled = false;
        m_rb.isKinematic = false;
        isTakingDamage = true;
    }

    /// <summary>
    /// Disables physics
    /// </summary>
    public void DisablePhysics()
    {
        zombieNavMesh.enabled = true;
        m_rb.isKinematic = true;
    }

    public void KillZombie(int isDeadHash)
    {
        StartCoroutine(KillZombieCoroutine(isDeadHash));
        if (!executeOnce)
        {
            executeOnce = true;
            GameManager.GetInstance().AddScore(10);
        }
    }


    /// <summary>
    /// Kill zombie, disable collision, make kinematic, disable zombie states
    /// </summary>
    IEnumerator KillZombieCoroutine(int isDeadHash)
    {
        //yield return new WaitForSeconds(2f);
        zombieAnimator.SetBool(isDeadHash, true);
        yield return new WaitForSeconds(3f);
        m_rb.isKinematic = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        
    }
}
