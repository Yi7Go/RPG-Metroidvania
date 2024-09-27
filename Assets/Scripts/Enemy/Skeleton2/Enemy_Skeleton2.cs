using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton2 : Enemy

{
    public Skeleton2IdleState idleState { get; private set; }
    public Skeleton2AttackState attackState { get; private set; }
    public Skeleton2BattleState battleState { get; private set; }
    public Skeleton2DeadState deadState { get; private set; }
    public Skeleton2MoveState moveState { get; private set; }

    public Skeleton2StunnedState StunnedState { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        idleState = new Skeleton2IdleState(this,stateMachine,"Idle",this);
        attackState = new Skeleton2AttackState(this, stateMachine, "Attack", this);
        battleState = new Skeleton2BattleState(this, stateMachine, "Move", this);
        deadState = new Skeleton2DeadState(this, stateMachine, "Idle", this);
        moveState = new Skeleton2MoveState(this, stateMachine, "Move", this);
        StunnedState = new Skeleton2StunnedState(this, stateMachine, "Stunned", this);

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }


    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(deadState);
    }
}
