using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text itemText;

    void Start()
    {
        itemText.text = "Score: " + ItemCollector.apple;
    }

    
}
