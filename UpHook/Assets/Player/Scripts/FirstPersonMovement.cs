using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        // Получение Rigidbody на объекте
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Обновляем статус бега
        IsRunning = canRun && Input.GetKey(runningKey);

        // Определяем целевую скорость перемещения
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Получаем ввод по горизонтали и вертикали
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Если есть движение
        if (targetVelocity.sqrMagnitude > 0.01f)
        {
            // Расчет направления движения
            Vector3 moveDirection = transform.rotation * new Vector3(targetVelocity.x, 0, targetVelocity.y);
            // Поворот игрока не делаем
        }

        // Применяем движение без изменения поворота
        Vector3 velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        rigidbody.velocity = velocity;
    }
}
