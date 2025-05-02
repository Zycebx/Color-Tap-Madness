using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    
    public GameObject[] circlePrefabs;
    public float spawnInterval = 1.5f;
    private float timer = 0f;

 
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnCircle();
            timer = 0f;
        }
    }

    void SpawnCircle()
    {
        int rand = Random.Range(0, circlePrefabs.Length);
        float xPos = Random.Range(-2f, 2f);
        Vector3 spawnPos = new Vector3(xPos, 5f, 0f);
        Instantiate(circlePrefabs[rand], spawnPos, Quaternion.identity);
    }
}
