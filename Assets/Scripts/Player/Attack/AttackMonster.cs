using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMonster : MonoBehaviour
{

    public GameObject player;
    private bool attackStatus = false;

    void Update()
    {
        attackStatus = player.GetComponent<Player>().playerControl.getAttackStatus();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("GameObject1 collided with " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy") && attackStatus)
        {
            collision.gameObject.GetComponent<Enemy>().health.getDamaged(player.GetComponent<Player>().attackDamage);
            collision.gameObject.GetComponent<Enemy>().health.isImmune=true;
            Debug.Log("Attack Monster");

        }


    }
}
