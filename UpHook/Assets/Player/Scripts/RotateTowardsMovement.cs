// using UnityEngine;

// public class RotateTowardsMovement : MonoBehaviour
// {
//     public Vector3 movementDirection; // Укажите здесь направление движения
//     public float rotationSpeed = 5f;   // Скорость поворота

//     void Update()
//     {
//         // Если вектор направления нулевой, ничего не делаем
//         if (movementDirection.sqrMagnitude == 0)
//             return;

//         // Рассчитываем целевую ориентацию
//         Quaternion targetRotation = Quaternion.LookRotation(movementDirection.normalized);

//         // Плавно поворачиваем объект к нужной ориентации
//         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target;
    public float rotationSpeed = 5.0f;

    private Vector3 currentDirection;
    private Quaternion targetRotation;

    void Start()
    {
        // Получаем направление от объекта к целевой точке
        currentDirection = (target.position - transform.position).normalized;
    }

    void Update()
    {
        // Получаем новое направление
        currentDirection = (target.position - transform.position).normalized;

        // Рассчитываем целевую ротацию
        targetRotation = Quaternion.LookRotation(currentDirection, Vector3.up);

        // Аанимировка объекта
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}