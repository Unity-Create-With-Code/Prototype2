using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30.0f;
    public float bottomBound = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z > topBound)
        {
            // Destroys projectile when it exists the top of the screen
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBound)
        {
            // Game is over if any animal exists the bottom of the screen
            // Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
