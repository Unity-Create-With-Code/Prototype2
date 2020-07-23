using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnManager;

    private int numLives = 3;
    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives = " + numLives + " Score = " + playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimalFed()
    {
        ++playerScore;
        Debug.Log("Score = " + playerScore);
    }

    public void PlayerHit()
    {
        --numLives;
        Debug.Log("Lives = " + numLives);
        if (numLives == 0)
        {
            Debug.Log("GAME OVER");
        }
    }
}
