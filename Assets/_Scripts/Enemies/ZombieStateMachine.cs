using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : MonoBehaviour
{
    public State currentState { get; private set; }

    protected Dictionary<ZombieStateType, State> states;

    private bool isRunning;

    private void Awake()
    {
        states = new Dictionary<ZombieStateType, State>();
    }

    /// <summary>
    /// Initialize the ZombieStateMachine
    /// </summary>
    /// <param name="startingState"></param>
    public void Initialize(ZombieStateType startingState)
    {
        if (states.ContainsKey(startingState))
        {
            ChangeState(startingState);
            Debug.Log("In state machine initialize");
        }
    }

    /// <summary>
    /// Add State
    /// </summary>
    /// <param name="stateName"></param>
    public void AddState(ZombieStateType stateName, State state)
    {
        if (states.ContainsKey(stateName))
        {
            return;
        }

        states.Add(stateName,state);
    }

    /// <summary>
    /// Remove a state
    /// </summary>
    /// <param name="stateName"></param>
    public void RemoveState(ZombieStateType stateName)
    {
        if (!states.ContainsKey(stateName))
        {
            return;
        }

        states.Remove(stateName);
    }


    /// <summary>
    /// Stop the current and change to next
    /// </summary>
    /// <param name="nextState"></param>
    public void ChangeState(ZombieStateType nextState)
    {
        if (isRunning)
        {
            // Stop the current state
            StopRunningState();
        }

        if (!states.ContainsKey(nextState))
        {
            return;
        }

        // Change to desired state and start it
        currentState = states[nextState];
        currentState.Start();

        if (currentState.UpdateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate), 0, currentState.UpdateInterval);
        }

        isRunning = true;
    }



    /// <summary>
    /// Stop the current state
    /// </summary>
    public void StopRunningState()
    {
        isRunning = false;
        currentState.Exit();
        CancelInvoke(nameof(IntervalUpdate));
    }


    /// <summary>
    /// Method for interval of change state
    /// </summary>
    void IntervalUpdate()
    {
        if (isRunning)
        {
            currentState.IntervalUpdate();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            currentState.Update();
        }
    }
}
