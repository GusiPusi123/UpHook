// using UnityEngine;

// public class BirdsSpawn : MonoBehaviour
// {
//     public Transform spawnPoint;        // Точка появления птиц
//     public Transform targetPoint;       // Точка назначения
//     public Collider triggerCollider;    // Коллайдер, активирующий выпуск птиц
//     public GameObject birdPrefab;       // Префаб птицы
//     public int birdCount = 5;           // Количество птиц
//     public float birdSpeed = 5f;        // Скорость полета птиц

//     private bool hasLaunched = false;   // Чтобы запускать птиц только один раз

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player") && !hasLaunched)
//         {
//             LaunchBirds();
//             hasLaunched = true;
//         }
//     }

//     private void LaunchBirds()
//     {
//         for (int i = 0; i < birdCount; i++)
//         {
//             GameObject bird = Instantiate(birdPrefab, spawnPoint.position, Quaternion.identity);
//             bird.tag = "Bird"; // Назначение тега "Bird"
//             StartCoroutine(MoveBirdToTarget(bird));
//         }
//     }

//     private System.Collections.IEnumerator MoveBirdToTarget(GameObject bird)
//     {
//         while (bird != null)
//         {
//             Vector3 currentPos = bird.transform.position;
//             Vector3 targetPos = targetPoint.position;
//             Vector3 direction = (targetPos - currentPos).normalized;

//             bird.transform.position += direction * birdSpeed * Time.deltaTime;

//             if (Vector3.Distance(bird.transform.position, targetPos) < 0.1f)
//             {
//                 Destroy(bird);
//                 yield break;
//             }

//             yield return null;
//         }
//     }
// }

using UnityEngine;

public class BirdsSpawn : MonoBehaviour
{
    public Transform spawnPoint;        // Точка появления птиц
    public Transform targetPoint;       // Точка назначения
    public Collider triggerCollider;    // Коллайдер, активирующий выпуск птиц
    public GameObject birdPrefab;       // Префаб птицы
    public int birdCount = 5;           // Количество птиц
    public float birdSpeed = 5f;        // Скорость полета птиц
    public float spawnRadius = 1f;      // Радиус случайного смещения при спавне

    private bool hasLaunched = false;   // Чтобы запускать птиц только один раз

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasLaunched)
        {
            LaunchBirds();
            hasLaunched = true;
        }
    }

    private void LaunchBirds()
    {
        for (int i = 0; i < birdCount; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                0,
                Random.Range(-spawnRadius, spawnRadius)
            );

            Vector3 spawnPosition = spawnPoint.position + randomOffset;
            GameObject bird = Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
            bird.tag = "Bird"; // Назначение тега "Bird"
            StartCoroutine(MoveBirdToTarget(bird));
        }
    }

    private System.Collections.IEnumerator MoveBirdToTarget(GameObject bird)
    {
        while (bird != null)
        {
            Vector3 currentPos = bird.transform.position;
            Vector3 targetPos = targetPoint.position;
            Vector3 direction = (targetPos - currentPos).normalized;

            bird.transform.position += direction * birdSpeed * Time.deltaTime;

            if (Vector3.Distance(bird.transform.position, targetPos) < 0.1f)
            {
                Destroy(bird);
                yield break;
            }

            yield return null;
        }
    }
}