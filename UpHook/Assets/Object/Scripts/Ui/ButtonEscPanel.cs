using UnityEngine;

public class ButtonEscPanel : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

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

    private void ManageCursorAndTime(bool pauseState)
    {
        if (pauseState)
        {
            // Открываем панель: отключаем управление, показываем курсор, ставим игру на паузу
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            // Закрываем панель: включаем управление, скрываем курсор, продолжаем игру
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
}