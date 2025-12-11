using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Alyza Castro
 * 12/10/25
 * script that controls the game over/end scene of game
 */


public class EndScreen : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
