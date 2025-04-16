using UnityEngine;
using System.Collections;

public class SpawnZone : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Vector3 size;

    public void StartSpawning()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        float duration = 60f;
        float interval = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            GameObject instantiated = GameObject.Instantiate(asteroidPrefab);
            instantiated.transform.position = new Vector3(
                Random.Range(transform.position.x - size.x / 2, transform.position.x + size.x / 2),
                Random.Range(transform.position.y - size.y / 2, transform.position.y + size.y / 2),
                Random.Range(transform.position.z - size.z / 2, transform.position.z + size.z / 2)
            );

            instantiated.AddComponent<AsteroidMover>();
            Destroy(instantiated, 5f);

            yield return new WaitForSeconds(interval);
            elapsedTime += interval;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
