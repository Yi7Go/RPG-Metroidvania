using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlewState : EnemyState
{
    protected Transform player;
    protected Enemy_Fly enemy;
    public FlewState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Fly _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {

        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


    }
}
