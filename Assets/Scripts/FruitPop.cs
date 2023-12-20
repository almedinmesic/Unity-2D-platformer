using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPop : MonoBehaviour
{
    private Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            anim.SetTrigger("collected");
        }
    }

    private void DestroyFruit()
    {
        Destroy(gameObject);
    }
    
}
