using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Frederick Southworth
 * 12/10/2025
 * This script shall control the web the spider shoots, how it acts, moves, and interacts with things within the game
 */

public class Web : MonoBehaviour
{
    public int webDamage = 1;
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.GetComponent<SpiderScript>())
        {
               Destroy(gameObject);
        }
    }
}
