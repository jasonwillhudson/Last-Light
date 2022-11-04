using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMonster : MonoBehaviour
{

    public GameObject player;
    private bool attackStatus = false;
    private bool cooldown = false;

    void Update()
    {
        attackStatus = player.GetComponent<Player>().playerControl.getAttackStatus();
        if (!attackStatus) cooldown = false; //reset cooldown

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("GameObject1 collided with " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy") && attackStatus && !cooldown)
        {
            collision.gameObject.GetComponent<Enemy>().health.getDamaged(player.GetComponent<Player>().attackDamage);
            Debug.Log("Attack Monster");
            cooldown = true;

        }


    }
}
