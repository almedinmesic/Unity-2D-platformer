using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private TMP_Text livesText;
    private static int lives = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    
    }
    private void Update()
    {
        livesText.text = "Lives: " + lives;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        ItemCollector.apple = 0;
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        
        
    }

    private void RestartLevel()
    {
        lives--;
        //livesText.text = "Lives: " + lives;
        if(lives > 0)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }   
        else
        {
            SceneManager.LoadScene("Game Over");
        }
    }

}
