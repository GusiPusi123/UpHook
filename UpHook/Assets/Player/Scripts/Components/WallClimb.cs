using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public float climbSpeed = 3f;
    public float detectionDistance = 1f;
    public LayerMask climbableLayer;

    private Rigidbody rb;
    private bool isAttached = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Постоянная проверка касания стены
        bool touchingWall = Physics.Raycast(transform.position, transform.forward, detectionDistance, climbableLayer);

        if (touchingWall)
        {
            // Если нажата клавиша E, прикрепиться
            if (Input.GetKeyDown(KeyCode.E))
            {
                isAttached = true;
                rb.useGravity = false;
            }
        }
        else
        {
            // Если не касается стены, отключить лазание и включить гравитацию
            if (isAttached)
            {
                isAttached = false;
                rb.useGravity = true;
            }
        }

        if (isAttached)
        {
            // Управление лазанием
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 moveDirection = (transform.up * vertical + transform.right * horizontal).normalized;
            transform.position += moveDirection * climbSpeed * Time.deltaTime;

            // Отсоединение по F
            if (Input.GetKeyDown(KeyCode.F))
            {
                isAttached = false;
                rb.useGravity = true;
            }
        }
    }
}