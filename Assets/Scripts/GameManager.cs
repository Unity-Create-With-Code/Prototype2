using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TODO - Does the GameManager have to be a MonoBehavior?
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnManager;

    public GameObject livesUI;
    public GameObject scoreUI;
    public GameObject gameOverUI;

    private int numLives = 3;
    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        UpdateUI();
    }

    public void AnimalFed(int amount)
    {
        playerScore += amount;
        UpdateUI();
    }

    public void PlayerHit()
    {
        --numLives;
        numLives = Mathf.Clamp(numLives, 0, numLives);
        UpdateUI();

        if (numLives == 0)
        {
            gameOverUI.SetActive(true);
        }
    }

    private void UpdateUI()
    {
        livesUI.GetComponent<TextMeshProUGUI>().text = "Lives: " + numLives;
        scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + playerScore;
    }
}
