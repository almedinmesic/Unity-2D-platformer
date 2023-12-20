using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHit : MonoBehaviour
{
    private Animator anim;

    public int hitPoints = 5;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            ItemCollector.apple += hitPoints;
            ChangeTag("Untagged");
            anim.SetTrigger("hit");
        }
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
    
    void ChangeTag(string newTag)
    {
        
        gameObject.tag = newTag;
    }
}
