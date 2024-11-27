using UnityEngine;
using System;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] protected float speed;
    [SerializeField] protected float idleTime;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected float detectionRadius;

    protected Transform player;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Vector2 direction;
    protected bool isPlayerDetected;
    protected bool isIdle;

    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsIdle = Animator.StringToHash("IsIdle");

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = Vector2.right;
    }

    protected virtual void Update()
    {
        DetectPlayer();

        if (isPlayerDetected)
        {
            EnterAttackState();
        }
        else if (!isIdle)
        {
            Move();
        }
    }

    protected abstract void EnterAttackState();

    protected void DetectPlayer()
    {
        Collider2D detectedPlayer = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        isPlayerDetected = detectedPlayer != null;

        if (isPlayerDetected)
        {
            player = detectedPlayer.transform;
        }
        else
        {
            player = null;
        }
    }

    protected virtual void Move()
    {
        animator.SetBool(IsWalking, true);
        rb.velocity = direction * speed;
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool(IsWalking, false);
    }

    public void ChangeDirection()
    {
        StopMoving();
        direction = -direction;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void EnterIdleState()
    {
        isIdle = true;
        StopMoving();
        animator.SetBool(IsIdle, true);
        Invoke(nameof(ExitIdleState), idleTime);
    }

    private void ExitIdleState()
    {
        isIdle = false;
        animator.SetBool(IsIdle, false);
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
