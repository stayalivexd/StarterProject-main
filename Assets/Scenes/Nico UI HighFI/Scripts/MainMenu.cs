using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayComposingMode()
    {
        SceneManager.LoadSceneAsync("Composing Mode");
    }

    public void PlayPracticeModeSongs()
    {
        SceneManager.LoadSceneAsync("Practice Mode Songs");
    }

    public void PlayPracticeModeInstruments()
    {
        SceneManager.LoadSceneAsync("Practice Mode Instruments");
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
