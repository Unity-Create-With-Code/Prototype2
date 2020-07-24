using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;

    public GameObject[] animalPrefabs;

    private float spawnRangeX = 15.0f;

    private float minSpawnRangeZ = 0.0f;
    private float maxSpawnRangeZ = 15.0f;

    private float spawnPosLeftX = -15.0f;
    private float spawnPosRightX = 15.0f;

    private float spawnPosZ = 20.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    private float[] spawnDistribution = { 0.5f, 0.25f, 0.25f };

    // Start is called before the first frame update
    void Start()
    {
        // Convert spawnChance from a percentage for each location
        // to a cumulative percentage for easier lookup later.
        float spawnTarget = spawnDistribution[0];
        for (int i = 1; i < spawnDistribution.Length; ++i)
        {
            spawnTarget += spawnDistribution[i];
            spawnDistribution[i] = spawnTarget;
        }

        // After 2 seconds, starts spawning a random animal every 1.5 seconds.
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        float spawn = Random.Range(0.0f, 1.0f);

        Vector3 spawnPos;
        Quaternion rot;

        if (spawn < spawnDistribution[0])
        {
            // Spawn from top
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            rot = Quaternion.LookRotation(Vector3.back);
        }
        else if (spawn < spawnDistribution[1])
        {
            // Spawn from left
            spawnPos = new Vector3(spawnPosLeftX, 0, Random.Range(minSpawnRangeZ, maxSpawnRangeZ));
            rot = Quaternion.LookRotation(Vector3.right);
        }
        else
        {
            // Spawn from right
            spawnPos = new Vector3(spawnPosRightX, 0, Random.Range(minSpawnRangeZ, maxSpawnRangeZ));
            rot = Quaternion.LookRotation(Vector3.left);
        }

        GameObject go  = Instantiate(animalPrefabs[animalIndex], spawnPos, rot);
        go.GetComponent<Health>().player = player;
        go.GetComponent<Health>().gameManager = gameManager;
    }

}
