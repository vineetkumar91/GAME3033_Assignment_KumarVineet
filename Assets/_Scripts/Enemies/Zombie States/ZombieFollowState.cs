using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    private GameObject followTarget;
    private const float stoppingDistance = 1;
    private int movementZHash = Animator.StringToHash("MovementZ");

    public ZombieFollowState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombie, zombieStateMachine)
    {
        followTarget = _followTarget;
        UpdateInterval = 2f;
    }


    public override void Start()
    {
        base.Start();

        if (!ownerZombie.isTakingDamage)
        {
            ownerZombie.zombieNavMesh.SetDestination(followTarget.transform.position);
        }
        
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        
        if (!ownerZombie.isTakingDamage)
        {
            ownerZombie.zombieNavMesh.SetDestination(followTarget.transform.position);

            int number = Random.Range(0, 101);

            if (number >= 80 && number < 90)
            {
                ownerZombie.zombieSounds.PlaySound(ZombieSound.BASIC);
            }
            else if (number >= 90 && number <= 100)

            {
                ownerZombie.zombieSounds.PlaySound(ZombieSound.BASIC2);
            }
        }
    }


    public override void Update()
    {
        base.Update();
        float moveZ = (ownerZombie.zombieNavMesh.velocity.normalized.z != 0) ? 1 : 0;
        ownerZombie.zombieAnimator.SetFloat(movementZHash, moveZ);

        if (GameManager.GetInstance().isPlayerDead)
        {
            ZombieStateMachine.ChangeState(ZombieStateType.IDLING);
            return;
        }

        float distanceBetween = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);


        if (distanceBetween < stoppingDistance)
        {
            ZombieStateMachine.ChangeState(ZombieStateType.ATTACKING);
        }
    }
}
