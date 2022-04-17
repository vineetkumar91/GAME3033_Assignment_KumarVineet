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

        if (ownerZombie.zombieNavMesh.enabled)
        {
            ownerZombie.zombieNavMesh.isStopped = true;
            ownerZombie.zombieNavMesh.ResetPath();
        }


        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        
        
        ownerZombie.KillZombie(isDeadHash);

        //ownerZombie.zombieAnimator.SetBool(isDeadHash, true);

    }

    public override void Exit()
    {
        base.Exit();
        if (ownerZombie.zombieNavMesh.enabled)
        {
            ownerZombie.zombieNavMesh.isStopped = false;
            ownerZombie.zombieAnimator.SetBool(isDeadHash, false);
        }
    }

    /// <summary>
    /// Kill zombie, disable collision, make kinematic, disable zombie states
    /// </summary>
    //public void KillZombie()
    //{
    //    ownerZombie.m_rb.isKinematic = true;
    //    ownerZombie.GetComponent<CapsuleCollider>().enabled = false;
    //}
}
