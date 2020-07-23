using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10.0f;

    private float horizontalRange = 15.0f;
    private float minVerticalRange = 0.0f;
    private float maxVerticalRange = 15.0f;

    public GameObject projectilePrefab;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 deltaVec = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(deltaVec * Time.deltaTime * speed);

        float xpos = Mathf.Clamp(transform.position.x, -horizontalRange, horizontalRange);
        float zpos = Mathf.Clamp(transform.position.z, minVerticalRange, maxVerticalRange);
        transform.position = new Vector3(xpos, transform.position.y, zpos);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            go.GetComponent<DetectCollisions>().player = gameObject;
            go.GetComponent<DetectCollisions>().gameManager = gameManager;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Don't collide with food
        if (other.tag != "Food")
        {
            gameManager.GetComponent<GameManager>().PlayerHit();
        }
    }
}
