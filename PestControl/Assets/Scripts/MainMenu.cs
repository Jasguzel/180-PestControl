using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Alyza Castro
 * 12/10/2025
 * Handles Main Menu
 */
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
