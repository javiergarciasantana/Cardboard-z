using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public string gameSceneName = "Main Scene";
    private bool hasRestarted = false; // Flag para evitar múltiples reinicios

    void Update()
    {
        if (!hasRestarted && (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            RestartGame();
        }
    }

    public void PlayAgain()
    {
        RestartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    private void RestartGame()
    {
        hasRestarted = true; // Evita múltiples llamadas
        Debug.Log("Cargando escena principal");
        SceneManager.LoadScene(gameSceneName);
    }
}
