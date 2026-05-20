using UnityEngine;

public class SettingsPanel : MonoBehaviour
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
    }
}
