using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/*
 * Guzeldere, Jasmine
 * 12/10/2025
 * Managing some UI Components
 */
public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text doubloonsText;
    public TMP_Text scoreText;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerController.totalScore;
        doubloonsText.text = "Doubloons: " + playerController.doubloons;
        healthText.text = "Health Remaining: ";
    }
}
