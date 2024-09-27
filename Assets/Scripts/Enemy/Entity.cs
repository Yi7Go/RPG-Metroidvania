using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{

    #region components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    

    public SpriteRenderer sr{ get; private set; }
    public CharacterStats stats { get; private set; }
    public CapsuleCollider2D cd { get; private set; }

    #endregion
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    public System.Action onFlipped;


    [Header("Knockback info")]

    [SerializeField] protected Vector2 knockbackPower = new Vector2 (7,12);
    [SerializeField]protected Vector2 knockbackOffset = new Vector2 (.5f,2);
    [SerializeField] protected float knockbackDuration = .07f;
     protected bool isKnocked;


    [Header("Collision info")]
    public Transform attackCheck;
    public float attackCheckRadius =1.2f;
    [SerializeField] protected Transform groundeCheck;
    [SerializeField] protected float groundCheckDistance = 1;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance = .8f;
    [SerializeField] protected LayerMask whatIsGround;

    public int knockbackDir { get; private set; }



    protected virtual void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        cd = GetComponent<CapsuleCollider2D>();

    }


    protected virtual void Start()
    {
  


    }

    protected virtual void Update()
    { 
    
    
    }

    public virtual void SlowEntityBy(float _slowPercentage, float _slowDuration)
    {

    }

    protected virtual void ReturnDefaultSpeed()
    {
        anim.speed = 1;
    }

    public virtual void DamageImpack()
    {

        
        StartCoroutine("HitKnockback");


        //Debug.Log(gameObject.name + " was damaged");
     
    }

    public virtual void SetupKnockbackDir(Transform _damageDirection)
    {
        if (_damageDirection.position.x > transform.position.x)
            knockbackDir = -1;
        else if (_damageDirection.position.x < transform.position.x)
            knockbackDir = 1;
    }

    public void SetupKnockbackPower(Vector2 _knockbackpower) => knockbackPower = _knockbackpower;

    protected virtual IEnumerator HitKnockback()
    {
        isKnocked = true;

        float xOffset = Random.Range(knockbackOffset.x,knockbackOffset.y);

        rb.velocity = new Vector2((knockbackPower.x + xOffset) * knockbackDir,knockbackPower.y);

        yield return new WaitForSeconds(knockbackDuration);
        isKnocked = false;
        SetupZeroKnockbackPower();
    
    }

    protected virtual void SetupZeroKnockbackPower()
    {

    }
    #region Velocity
    public void SetZeroVelocity()
    {
        if (isKnocked)
            return;

        rb.velocity = new Vector2(0,0);
    }
    
        
   
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {

        if (isKnocked)
            return;


        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);

    }

    #endregion


    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundeCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    public virtual bool IswallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);


    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundeCheck.position, new Vector3(groundeCheck.position.x, groundeCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion


    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

        if(onFlipped != null)
        onFlipped();
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();

    }
    public virtual void SetupDefaultFacingDir(int _direction)
    {
        facingDir = _direction;

        if(facingDir == -1)
            facingRight = false;
    }


    public virtual void Die()
    {

    }




}
