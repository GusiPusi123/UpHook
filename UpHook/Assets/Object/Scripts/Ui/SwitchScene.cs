using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Название сцены, которую нужно загрузить
    public string sceneName;
    public void ChangeScene()
    {
        // Загружаем сцену по имени
        SceneManager.LoadScene(sceneName);
    }
}