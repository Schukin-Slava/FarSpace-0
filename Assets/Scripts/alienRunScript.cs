using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(TouchigDirections), typeof(DamageAble))]
public class alienRunScript : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float walkStopRate = 0.6f;
    public DitactionZone attackZone;
    Animator animator;
    DamageAble damageAble;
    public DitactionZone cliffDetectionZone;
    Rigidbody2D rb;

    TouchigDirections touchigDirections;
    public enum WalkableDirection { Right, Left }

    private WalkableDirection _walkDirection;
    private Vector2 walkDiractionVector = Vector2.right;

    public WalkableDirection WalkDiraction
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    walkDiractionVector = Vector2.right;
                } else if (value == WalkableDirection.Left)
                {
                    walkDiractionVector = Vector2.left;
                }
            }

            _walkDirection = value;
        }
    }

    public bool _hasTarget = false;
 

    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchigDirections = GetComponent<TouchigDirections>();
        animator = GetComponent<Animator>();
        damageAble = GetComponent<DamageAble>();
    }

    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
    }

    public void FixedUpdate()
    {

        if (touchigDirections.IsGrounded && touchigDirections.IsOnWall || cliffDetectionZone.detectedColliders.Count == 0)
        {
            FlipDirection();
        }
        if (!damageAble.LockVelocity)
        {
            if (CanMove && touchigDirections.IsGrounded)
            {
                rb.velocity = new Vector2(walkSpeed * walkDiractionVector.x, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
            }
        }


    }

    private void FlipDirection()
    {
        if(WalkDiraction == WalkableDirection.Right)
        {
            WalkDiraction = WalkableDirection.Left;
        } else if (WalkDiraction == WalkableDirection.Left)
        {
            WalkDiraction = WalkableDirection.Right;
        }
        else
        {
            Debug.LogError("Error with directuions");
        }
    }

    public void OnHit(int damage,Vector2 knockBack)
    {
        rb.velocity = new Vector2(knockBack.x, rb.velocity.y + knockBack.y);
    }
}
