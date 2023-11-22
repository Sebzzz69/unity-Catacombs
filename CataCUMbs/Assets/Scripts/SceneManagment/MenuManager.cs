using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string levelSceneName;
    [SerializeField] string creditsSceneName;

    public void MainGame()
    {
        if (levelSceneName != null)
        {
            SceneManager.LoadScene(levelSceneName);
        }
        else
        {
            Debug.Log("Main Game");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void CreditsMenu()
    {
        if (creditsSceneName != null)
        {
            SceneManager.LoadScene(creditsSceneName);
        }
        else
        {
            Debug.Log("Credits Menu");
        }
    }

}
