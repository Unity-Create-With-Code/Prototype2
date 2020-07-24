using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnManager;

    public GameObject livesUI;
    public GameObject scoreUI;

    private int numLives = 3;
    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
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
        UpdateUI();

        if (numLives == 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    private void UpdateUI()
    {
        livesUI.GetComponent<TextMeshProUGUI>().text = "Lives: " + numLives;
        scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + playerScore;
    }
}
