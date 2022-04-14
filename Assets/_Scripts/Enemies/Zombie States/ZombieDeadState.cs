using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    private int movementZHash = Animator.StringToHash("MovementZ");
    private int isDeadHash = Animator.StringToHash("IsDead");

    public ZombieDeadState(ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombie, zombieStateMachine)
    {

    }

    public override void Start()
    {
        base.Start();
        ownerZombie.zombieNavMesh.isStopped = true;
        ownerZombie.zombieNavMesh.ResetPath();

        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        ownerZombie.zombieAnimator.SetBool(isDeadHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieNavMesh.isStopped = false;
        ownerZombie.zombieAnimator.SetBool(isDeadHash, false);
    }
}
