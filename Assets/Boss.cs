using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;



[DisallowMultipleComponent]
public class Boss : MonoBehaviour
{

    [HideInInspector] public Health health;
    public GameObject healthbar;
    public GameObject deathEffect;
    public int numSkills = 2;
    private int currentSkill = 1;

    public GameObject beforeFirstAttack;
    public GameObject attackOneTop;
    public GameObject attackOneBottom;

    public GameObject beforeSecondtAttack;
    public GameObject bullet;
    private float cooldown = 2f;
    private float skillDuration = 2.4f;

    private bool isBeforeAttackgenerated = false;
    private bool isAttackgenerated = false;
    
    private float lasbulletTime = 0f;

    private void Awake()
    {
        // Load components

        //set the health
        health = GetComponent<Health>();
        health.SetStartHealth(100);

    }

    public void Update()
    {

     
        //reset cooldown after using skill
        if (skillDuration <= 0)
        {
            cooldown = 4f;

            //swithch skill
            if (currentSkill < numSkills) currentSkill++;
            else currentSkill = 1;

            if (currentSkill == 1) skillDuration = 2.4f;
            else if (currentSkill == 2) skillDuration = 7f;

            isAttackgenerated = false;
            isBeforeAttackgenerated = false;

            lasbulletTime = skillDuration;

        }
        if (cooldown > 0) cooldown -= Time.deltaTime;
        else
        {
            if (skillDuration > 0) skillDuration -= Time.deltaTime;

            if (currentSkill == 1)
            {
       
                //before attack
                if (skillDuration <= 2.4f && skillDuration > 2.3f && !isBeforeAttackgenerated)
                { 
                    var attack = Instantiate(beforeFirstAttack, transform.position, Quaternion.identity);
                    attack.transform.parent = gameObject.transform;
                    isBeforeAttackgenerated = true; 
                }

                //skill one
                else if (skillDuration <= 1.1f && skillDuration > 1f && !isAttackgenerated)
                {
                    Debug.Log("used skill one");
                    var attack = Instantiate(attackOneTop, transform.position, Quaternion.identity);
                    attack.transform.parent = gameObject.transform;
                    isAttackgenerated = true;
                    isBeforeAttackgenerated = false;
                }

            }
            else if (currentSkill == 2)
            {
                //use skill two
                if(lasbulletTime >= 0.3f + skillDuration)
                {
                    var attack = Instantiate(bullet, transform.position, Quaternion.identity);
                    attack.transform.parent = gameObject.transform;
                    lasbulletTime = skillDuration;
                }
            }
            else
            {
                //use skill three

            }

        }





        //get the health value right now
        float healthValue = health.getHealth();

        if (healthValue <= 0)
        {
            //generate death effect
            GameObject temp = Instantiate(deathEffect, transform.position, Quaternion.identity);
            transform.parent = temp.transform;

            Destroy(this.gameObject);
            EnemyDestroyed();

        }
        else
        {

            healthbar.transform.localScale = new Vector3(healthValue / 100, 1, 1);
        }
    }

    /// <summary>
    /// Enemy destroyed
    /// </summary>
    private void EnemyDestroyed()
    {
        DestroyedEvent destroyedEvent = GetComponent<DestroyedEvent>();
        destroyedEvent.CallDestroyedEvent();
    }


}
