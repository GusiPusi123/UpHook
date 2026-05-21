using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public float interactionDistance = 3f;
    public KeyCode interactKey = KeyCode.E;
    public Text interactionText;
    public string sceneName;
    public float delay = 2f;
    public Animator animator;
    public string triggerName = "Start";

    public Transform player;
    private bool isPlayerInTrigger = false;

    void Start()
    {
        // Попытка найти объект игрока по тегу "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Игрок с тегом 'Player' не найден в сцене.");
        }

        if (interactionText != null)
        {
            interactionText.enabled = false; // изначально скрываем текст
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Проверяем, нажата ли клавиша E и находится ли игрок в триггере
        if (Input.GetKeyDown(interactKey) && isPlayerInTrigger)
        {
            if (player != null)
            {
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance <= interactionDistance)
                {
                    // Переход на сцену
                    StartCoroutine(PlayAnimationAndSwitchScene());
                    // Скрываем текст
                    if (interactionText != null)
                    {
                        interactionText.enabled = false;
                    }
                }
            }
            else
            {
                Debug.LogWarning("Переменная player не назначена или не найдена.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что это игрок
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            if (interactionText != null)
            {
                interactionText.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, что это игрок
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (interactionText != null)
            {
                interactionText.enabled = false;
            }
        }
    }
    private IEnumerator PlayAnimationAndSwitchScene()
    {
        // Запускаем анимацию
        animator.SetTrigger(triggerName);
        Time.timeScale = 1f;

        // Ждём указанное время (длительность анимации)
        yield return new WaitForSeconds(delay);

        // Переключаем сцену
        SceneManager.LoadScene(sceneName);
    }
}