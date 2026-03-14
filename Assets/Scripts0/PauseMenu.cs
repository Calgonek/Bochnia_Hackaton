using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("UI References")]
    [SerializeField] private GameObject pauseMenuUI;

    // Tworzymy akcję wejścia (InputAction)
    private InputAction pauseAction;

    private void Awake()
    {
        // Konfigurujemy akcję: reaguje na wciśnięcie przycisku Escape na klawiaturze
        pauseAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/escape");
        
        // Podpinamy naszą metodę TogglePause pod moment "wykonania" akcji (wciśnięcia klawisza)
        pauseAction.performed += context => TogglePause();
    }

    // Ważne: Akcje trzeba włączać i wyłączać, żeby uniknąć wycieków pamięci
    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    public void TogglePause()
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

    public void Resume()
    {
        if (pauseMenuUI == null) return;
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        if (pauseMenuUI == null) return;
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Wychodzenie z gry...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}