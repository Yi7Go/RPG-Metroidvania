using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Enemy_Fly : Enemy
{

    public int damage;
    public PlayerStats health;
    public FlyIdleState idleState { get; private set; }
    public FlyMoveState moveState { get; private set; }

    public FlyDeadState deadState { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);
        }

    }
    protected override void Awake()
    {
        base.Awake();

        idleState = new FlyIdleState(this, stateMachine, "Idle", this);
        moveState = new FlyMoveState(this, stateMachine, "Move", this);
        deadState = new FlyDeadState(this, stateMachine, "Dead", this);



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


    public void SelfDestroy() => Destroy(gameObject);

}
