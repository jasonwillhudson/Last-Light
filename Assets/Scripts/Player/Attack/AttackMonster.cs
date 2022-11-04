using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMonster : MonoBehaviour
{

    public GameObject player;
    private bool attackStatus=false;
    private bool cooldown=false;

    void Update()
    {
        attackStatus = player.GetComponent<Player>().playerControl.getAttackStatus();
        if (!attackStatus) cooldown = false; //reset cooldown
       
    }
    void OnTriggerEnter2D(Collision2D collision)
    {

        Debug.Log("GameObject1 collided with ");
        if (collision.collider.gameObject.CompareTag("Enemy") && attackStatus && !cooldown)
        {
            collision.collider.gameObject.GetComponent<Enemy>().health.getDamaged(20);
            Debug.Log("Attack Monster");
            cooldown = true;

        }

        
    }
}
