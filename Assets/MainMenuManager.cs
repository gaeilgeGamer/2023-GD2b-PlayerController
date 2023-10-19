using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "GameScene";
    [SerializeField]
    private string optionsSceneName = "OptionsScene";
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(optionsSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
