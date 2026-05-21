using UnityEngine;

public class BounceOnLayer : MonoBehaviour
{
    public float bounceForce = 10f;
    public string wallLayerName = "Wall"; // Название слоя стены

    private Rigidbody rb;
    private int wallLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wallLayer = LayerMask.NameToLayer(wallLayerName);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == wallLayer)
        {
            // Получаем контактную точку
            ContactPoint contact = collision.contacts[0];
            // Направление от поверхности стены
            Vector3 bounceDirection = contact.normal;
            // Отталкиваемся в обратную сторону поверхности
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}