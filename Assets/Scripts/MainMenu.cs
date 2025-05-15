using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string m_GameScene;

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(m_GameScene);
    }
    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
