using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Destroy(GameObject.FindObjectOfType<Highscore>());
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Titel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
