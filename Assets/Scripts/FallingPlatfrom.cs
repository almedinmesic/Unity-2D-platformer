using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatfrom : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;
    public float delayFall = 1f;
    public float delayDestroy = 1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !isFalling)
        {
            Invoke("Fall", delayFall); 
            isFalling = true;
        }
    }

    private void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Invoke("DestroyPlatform", delayDestroy);
    }

    private void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
