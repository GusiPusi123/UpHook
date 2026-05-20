using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform playerModel; // Модель игрока, которую нужно поворачивать
    public float rotationSpeed = 10f; // Скорость поворота

    private CharacterController controller; // Или Rigidbody, если используете Rigidbody

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (playerModel == null)
        {
            Debug.LogError("Укажите модель игрока в инспекторе");
        }
    }

    void Update()
    {
        // Получаем входные данные по оси направления
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Проверяем, есть ли движение
        if (direction.magnitude > 0.1f)
        {
            // Вычисляем нужный угол
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Плавный поворот модели
            float angle = Mathf.LerpAngle(playerModel.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
            playerModel.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}