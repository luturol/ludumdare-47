using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // só funciona em .exe, no unity ele não fecha o 'run' do unity
    public void QuitGame()
    {
        Application.Quit();
    }
}
