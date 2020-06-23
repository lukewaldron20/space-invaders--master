using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DiceGame : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
