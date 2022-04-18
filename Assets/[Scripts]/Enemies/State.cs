using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected ZombieStateMachine ZombieStateMachine;

    public float UpdateInterval { get; protected set; } = 1f;

    protected State(ZombieStateMachine zombieStateMachine)
    {
        ZombieStateMachine = zombieStateMachine;
    }

    public virtual void Start()
    {

    }

    public virtual void IntervalUpdate()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
