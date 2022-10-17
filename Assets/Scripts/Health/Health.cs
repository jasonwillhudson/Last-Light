using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private int startHealth;
    private int currentHealth;

    public void SetStartHealth(int startHealth)
    {
        this.startHealth = startHealth;
        currentHealth = startHealth;
    }

    public void getDamaged(int damage)
    {
        currentHealth -= damage;
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
