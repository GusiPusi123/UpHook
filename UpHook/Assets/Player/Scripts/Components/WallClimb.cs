// using UnityEngine;

// public class WallClimb : MonoBehaviour
// {
//     public float climbSpeed = 3f;
//     public float detectionDistance = 1f;
//     public LayerMask climbableLayer;
//     public Animator animator; // Добавляем компонент Animator

//     private Rigidbody rb;
//     private bool isAttached = false;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     void Update()
//     {
//         // Постоянная проверка касания стены
//         bool touchingWall = Physics.Raycast(transform.position, transform.forward, detectionDistance, climbableLayer);

//         if (touchingWall)
//         {
//             // Если нажата клавиша E, прикрепиться
//             if (Input.GetKeyDown(KeyCode.E))
//             {
//                 isAttached = true;
//                 rb.useGravity = false;

//                 // Включить анимацию залаза
//                 if (animator != null)
//                 {
//                     animator.SetTrigger("ClimbStart");
//                 }
//             }
//         }
//         else
//         {
//             // Если не касается стены, отключить лазание и включить гравитацию
//             if (isAttached)
//             {
//                 isAttached = false;
//                 rb.useGravity = true;
//             }
//         }

//         if (isAttached)
//         {
//             // Управление лазанием
//             float vertical = Input.GetAxis("Vertical");
//             float horizontal = Input.GetAxis("Horizontal");
//             Vector3 moveDirection = (transform.up * vertical + transform.right * horizontal).normalized;
//             transform.position += moveDirection * climbSpeed * Time.deltaTime;

//             // Отсоединение по F
//             if (Input.GetKeyDown(KeyCode.F))
//             {
//                 isAttached = false;
//                 rb.useGravity = true;
//             }
//         }
//     }
// }

using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public float climbSpeed = 3f;
    public float detectionDistance = 1f;
    public LayerMask climbableLayer;
    public Animator animator; // Компонент Animator

    private Rigidbody rb;
    private bool isAttached = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Проверка касания стены
        bool touchingWall = Physics.Raycast(transform.position, transform.forward, detectionDistance, climbableLayer);

        if (touchingWall)
        {
            // Начать лазание по нажатию E
            if (Input.GetKeyDown(KeyCode.E))
            {
                isAttached = true;
                rb.useGravity = false;

                // Можно инициировать анимацию начала лазания
                // (если нужно, например, trigger)
            }
        }
        else
        {
            // Отключить лазание, если не касаешься стены
            if (isAttached)
            {
                isAttached = false;
                rb.useGravity = true;

                // Отключить анимацию
                if (animator != null)
                {
                    animator.SetBool("IsClimbing", false);
                }
            }
        }

        if (isAttached)
        {
            // Управление лазанием
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 moveDirection = (transform.up * vertical + transform.right * horizontal).normalized;

            // Перемещение
            transform.position += moveDirection * climbSpeed * Time.deltaTime;

            // Управление анимацией
            if (animator != null)
            {
                // Включать анимацию, если игрок движется
                bool isMoving = Mathf.Abs(vertical) > 0.1f || Mathf.Abs(horizontal) > 0.1f;
                animator.SetBool("IsClimbing", isMoving);
            }

            // Отсоединение по F
            if (Input.GetKeyDown(KeyCode.F))
            {
                isAttached = false;
                rb.useGravity = true;

                // Отключить анимацию
                if (animator != null)
                {
                    animator.SetBool("IsClimbing", false);
                }
            }
        }
    }
}