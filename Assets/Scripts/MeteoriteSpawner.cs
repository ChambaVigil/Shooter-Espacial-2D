using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject meteoritePrefab;
    public float ratePerMinute = 30f;
    public float spawnRateIncrement= 1f;
    public float xLimit;
    private float spawnNext = 0;
    public float maxLifetime = 5f;
    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / ratePerMinute;
            ratePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xLimit, xLimit);
            Vector2 spawnPosition = new Vector2(rand, 8);
            GameObject meteorite = Instantiate(meteoritePrefab, spawnPosition, Quaternion.identity);
            Destroy(meteorite, maxLifetime);
        }
    }
}
