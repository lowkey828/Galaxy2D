using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int minX = -8, maxX = 12, maxY = 7;
    public float spawnTime = 5f;

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnTime);
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnRotation = new Vector2(randomX, maxY);

        GameObject asteroidNew = Instantiate(asteroidPrefab, spawnRotation, Quaternion.identity);

        int randomScale = Random.Range(1, 4);
        asteroidNew.transform.localScale = new Vector3(randomScale, randomScale, 1);

        Asteroid asteroid = asteroidNew.GetComponent<Asteroid>();
        if (randomScale == 3)
        {
            asteroid.health = 10;
        }
        else if (randomScale == 2)
        {
            asteroid.health = 7;
        }
        else
        {
            asteroid.health = 5;
        }

        Rigidbody2D rb = asteroidNew.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-0.5f, -1);
        }
    }
}
