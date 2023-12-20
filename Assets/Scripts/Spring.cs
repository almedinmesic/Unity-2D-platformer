using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private Animator anim;
    public float jumpforce = 11f;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            anim.SetBool("isJumped", true);
        }
        if(collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb =collision.collider.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;

            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Invoke("isJumped",0.25f);
        }
        
    }

    private void isJumped()
    {
        anim.SetBool("isJumped", false);
    }
}
