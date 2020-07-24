using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 0;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
    }

    public void ModifyHealth(int amount)
    {
        Debug.Log("ModifyHealth = " + amount);
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
