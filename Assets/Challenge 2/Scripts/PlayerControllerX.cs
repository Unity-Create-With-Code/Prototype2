using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float waitTimeToSpawnDog = 2.0f;
    private float elapsedDogSpawnTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        elapsedDogSpawnTime += Time.deltaTime;

        // On spacebar press, send dog
        if (elapsedDogSpawnTime > waitTimeToSpawnDog && Input.GetKeyDown(KeyCode.Space))
        {
            elapsedDogSpawnTime = 0.0f;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
