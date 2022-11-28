using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private int startHealth;
    private int currentHealth;
    private float cooldown = 0.2f;
    [HideInInspector] public bool isImmune = false;

    private void Update()
    {
        immuneCountDown();
    }
    public void SetStartHealth(int startHealth)
    {
        this.startHealth = startHealth;
        currentHealth = startHealth;
    }

    public void getDamaged(int damage)
    {
        if(!isImmune) currentHealth -= damage;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void gainHealth(int p)
    {
        currentHealth += p;
        if (currentHealth > 6) currentHealth = 6;
    }

    private void immuneCountDown()
    {
        cooldown -= Time.deltaTime;

        if (isImmune && cooldown < 0)
        {

            isImmune = false; // make sure we dont' call this again

        }
    }
}
