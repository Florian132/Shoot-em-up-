using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Destroy(GameObject.Find("ScoreHolder"));
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Titel");
        Destroy(GameObject.Find("ScoreHolder"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
