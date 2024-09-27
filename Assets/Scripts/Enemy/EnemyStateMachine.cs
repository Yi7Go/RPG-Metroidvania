using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState currenState { get; private set; }

    public void Initialize(EnemyState _startState)
    {
        currenState = _startState;
        currenState.Enter();
    
    
    }

    public void ChangeState(EnemyState _newState)
    {
        currenState.Exit();
        currenState = _newState;
        currenState.Enter(); 

    
    
    }



}
