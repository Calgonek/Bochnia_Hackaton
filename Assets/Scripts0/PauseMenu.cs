using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Zmienna statyczna, żeby łatwo sprawdzać z innych skryptów, czy gra jest zapauzowana
    public static bool GameIsPaused = false; 

    [Header("UI References")]
    public GameObject pauseMenuUI;

    void Update()
    {
        // Sprawdzamy, czy gracz wcisnął klawisz Escape (możesz to zmienić na inny)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Metoda publiczna, aby można było ją podpiąć pod przycisk
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Wyłącza panel menu
        Time.timeScale = 1f;          // Przywraca normalny upływ czasu
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);  // Włącza panel menu
        Time.timeScale = 0f;          // Zatrzymuje czas w grze
        GameIsPaused = true;
    }

    // Metoda publiczna dla przycisku wyjścia
    public void QuitGame()
    {
        Debug.Log("Wychodzenie z gry...");
        Application.Quit(); // Uwaga: To zadziała tylko po zbudowaniu gry, nie w edytorze
    }
}