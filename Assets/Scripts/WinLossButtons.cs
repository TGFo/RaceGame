using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossButtons : MonoBehaviour
{
    string currentScene;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
