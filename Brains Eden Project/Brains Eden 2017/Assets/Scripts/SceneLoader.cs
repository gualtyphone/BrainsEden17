using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader m_sceneLoader;

    // Use this for initialization
    private void Awake()
    {
        if (m_sceneLoader)
        {
            Destroy(m_sceneLoader);
            m_sceneLoader = this;
        }
        else
        {
            m_sceneLoader = this;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadArena1()
    {
        SceneManager.LoadScene("ArenaTest");
    }

    public void ExitGame()
    {
        print("quitting");
        Application.Quit();
    }
}