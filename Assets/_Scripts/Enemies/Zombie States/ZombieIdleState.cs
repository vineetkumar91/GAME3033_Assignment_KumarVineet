using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieStates
{
    private int movementZHash = Animator.StringToHash("MovementZ");

    public ZombieIdleState(ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombie, zombieStateMachine)
    {

    }
    public override void Start()
    {
        base.Start();

        if (ownerZombie.zombieNavMesh.enabled)
        {
            ownerZombie.zombieNavMesh.isStopped = true;
            ownerZombie.zombieNavMesh.ResetPath();
        }


        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
    }

    public override void Exit()
    {
        base.Exit();
        if (ownerZombie.zombieNavMesh.enabled)
        {
            ownerZombie.zombieNavMesh.isStopped = false;
        }
    }
}
