﻿using System;
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
    public GameObject splatPrefab;

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
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

    private void OnTriggerEnter(Collider other)
    {
        // Don't collide with food
        if (other.tag != "Food")
        {
            gameManager.GetComponent<GameManager>().PlayerHit();
            Instantiate(splatPrefab, transform.position, Quaternion.identity);
        }
    }
}
