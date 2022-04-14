using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ZombieStateType
{
    IDLING,
    ATTACKING,
    FOLLOWING,
    IS_DEAD,
    TOTAL_STATES
}

public class ZombieStates : State
{
    protected ZombieComponent ownerZombie;

    public ZombieStates(ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombieStateMachine)
    {
        ownerZombie = zombie;
    }
}
