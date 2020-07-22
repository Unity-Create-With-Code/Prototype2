using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10.0f;

    public float horizontalRange = 10.0f;
    public float minVerticalRange = 0.0f;
    public float maxVerticalRange = 5.0f;

    public GameObject projectilePrefab;

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
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
