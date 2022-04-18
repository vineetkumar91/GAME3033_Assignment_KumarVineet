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
    public ZombieSounds zombieSounds;

    public bool isTakingDamage = false;
    private bool executeOnce = false;

    private float attackRange = 4f;

    // interface for damageable object here
    private IDamageable damageableObject;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        zombieNavMesh = GetComponent<NavMeshAgent>();
        zombieStateMachine = GetComponent<ZombieStateMachine>();
        m_rb = GetComponent<Rigidbody>();
        zombieSounds = GetComponent<ZombieSounds>();
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

        damageableObject = followTarget.GetComponent<IDamageable>();
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

            int roll = Random.Range(0, 11);
            if (roll > 7)
            {
                zombieSounds.PlaySound(ZombieSound.FEMALE);
            }
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


    /// <summary>
    /// public function for animation call
    /// if in range, then only takes damage
    /// </summary>
    public void GiveDamage()
    {
        if (GameManager.GetInstance().isPlayerDead)
        {
            return;
        }

        float distanceBetween = Vector3.Distance(transform.position, followTarget.transform.position);

        if (distanceBetween <= attackRange)
        {
            // Deal damage
            damageableObject.TakeDamage(zombieDamage);
        }
    }
}
