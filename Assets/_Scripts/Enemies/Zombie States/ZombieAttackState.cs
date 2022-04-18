using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    private GameObject followTarget;
    private float attackRange = 2;

   

    private int movementZHash = Animator.StringToHash("MovementZ");
    private int isAttackingHash = Animator.StringToHash("IsAttacking");

    // Start is called before the first frame update
    public ZombieAttackState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombie, zombieStateMachine)
    {
        followTarget = _followTarget;
        UpdateInterval = 2;

    }

    public override void Start()
    {
        //base.Start();

        if (ownerZombie.zombieNavMesh.enabled)
        {
            ownerZombie.zombieNavMesh.isStopped = true;
            ownerZombie.zombieNavMesh.ResetPath();
        }

        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        ownerZombie.zombieAnimator.SetBool(isAttackingHash, true);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        // Add interval

        
    }

    public override void Update()
    {
        //base.Update();
        ownerZombie.transform.LookAt(followTarget.transform.position, Vector3.up);

        if (GameManager.GetInstance().isPlayerDead)
        {
            ZombieStateMachine.ChangeState(ZombieStateType.IDLING);
            return;
        }

        float distanceBetween = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);

        if (distanceBetween > attackRange)
        {
            ZombieStateMachine.ChangeState(ZombieStateType.FOLLOWING);
        }
    }

    public override void Exit()
    {
        base.Exit();

        if (ownerZombie.zombieNavMesh.enabled)
        {
            ownerZombie.zombieNavMesh.isStopped = false;
        }
        ownerZombie.zombieAnimator.SetBool(isAttackingHash, false);
    }
}
