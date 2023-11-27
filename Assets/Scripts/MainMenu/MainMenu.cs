using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CheckpointRaceBtn()
    {
        SFXManager.instance.PlaySound("honk");
        SceneManager.LoadScene("CheckpointRaceDialogue");
    }
    public void BeginnerRaceBtn()
    {
        SFXManager.instance.PlaySound("CarDoorOpen");
        SceneManager.LoadScene("BeginnerRaceDialogue");
    }
    public void AdvancedRaceBtn()
    {
        SFXManager.instance.PlaySound("EngineStart1");
        SceneManager.LoadScene("AdvancedRaceDialogue");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
