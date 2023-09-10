using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
}
