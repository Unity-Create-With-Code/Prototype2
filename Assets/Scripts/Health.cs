using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 0;

    private GameObject player;
    private GameObject gameManager;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    public void ModifySpeed()
    {
        float speed = GetComponent<MoveForward>().speed;
        GetComponent<MoveForward>().speed = speed * 0.75f;
    }

    // TODO - Move to a DetectCollision script.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(other.gameObject);
            ModifyHealth(20);
            ModifySpeed();

            int amount = 20;
            if (currentHealth >= maxHealth)
            {
                amount += maxHealth;
                Destroy(gameObject);
            }

            gameManager.GetComponent<GameManager>().AnimalFed(amount);
        }
    }
}
