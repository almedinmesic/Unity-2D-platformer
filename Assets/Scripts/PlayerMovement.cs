using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float move_speed = 7f;
    public float jump_speed = 7f; 

    private BoxCollider2D coll;
    [SerializeField] private LayerMask ground;

    private Animator anim;
    private SpriteRenderer sprite;

    float dirX = 0;

    public float grvScale = 2.5f;

    private enum MovementState{idle, run, jump, fall};

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * move_speed , rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x,jump_speed);
            jumpSoundEffect.Play();
        }
        Animation();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
        
    }

    private void Animation()
    {
        MovementState state;
        rb.gravityScale = 1;
        
        if(dirX >0)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if(dirX < 0)
        {
            state = MovementState.run;
            sprite.flipX = true;

        }
        else 
        {
            state = MovementState.idle;
           
        }

        if(rb.velocity.y > 0.1)
        {
            state = MovementState.jump;
            //rb.gravityScale = 1;
        }
        else if( rb.velocity.y < -0.1)
        {
            state = MovementState.fall;
            rb.gravityScale = grvScale;
        }

        anim.SetInteger("state", (int)state);
        
    }
}
