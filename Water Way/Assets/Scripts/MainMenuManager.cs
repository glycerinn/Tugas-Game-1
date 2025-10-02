using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip myClip;
    public void PlayGame()
    {
        Click();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Click();
        Application.Quit();
    }

    public void Click()
    {
        mySource.clip = myClip;
        mySource.Play();
    }
}
