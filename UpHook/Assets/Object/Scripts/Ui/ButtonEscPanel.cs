using UnityEngine;
using UnityEngine.UI; // Для работы с UI Button

public class ButtonEscPanel : MonoBehaviour
{
    public GameObject pausePanel;
    public Button closeButton; // UI кнопка, которую можно назначить через инспектор

    private bool isPaused = false;

    void Start()
    {
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePausePanel);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (pausePanel == null)
        {
            Debug.LogWarning("Pause Panel не назначен!");
            return;
        }

        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        ManageCursorAndTime(isPaused);
    }

    public void ManageCursorAndTime(bool pauseState)
    {
        if (pauseState)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    // Метод вызывается при нажатии на UI кнопку
    public void ClosePausePanel()
    {
        if (isPaused)
        {
            TogglePause();
        }
    }
}