using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager == null)
        {
            Debug.Log("NULL in " + gameObject.name);
        }

        if (other.gameObject != player)
        {
            Destroy(gameObject);
            // Destroy(other.gameObject);

            gameManager.GetComponent<GameManager>().AnimalFed();
        }
    }
}
