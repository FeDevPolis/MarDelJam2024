using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    //public void LoadGameOver()
    //{
    //    SceneManager.LoadScene(2);
    //}

    public static void LoadCredits()
    {
        SceneManager.LoadScene(2);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
