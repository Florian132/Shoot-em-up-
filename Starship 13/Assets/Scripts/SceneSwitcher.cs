using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoPlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void GotoQuitScene()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}