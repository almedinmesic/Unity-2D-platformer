using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemCollector : MonoBehaviour
{
    public static int apple = 0;
    [SerializeField] private TMP_Text itemText;

    [SerializeField] private AudioSource collectSoundEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            //Destroy(collision.gameObject);
            collectSoundEffect.Play();
            apple++;
            
        }
    }

    private void Update()
    {
        itemText.text = "Score: " + apple;
    }
}
    
