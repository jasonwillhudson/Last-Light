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
            collision.gameObject.transform.Find("hitEffect").gameObject.GetComponent<ParticleSystem>().Play();
            //Debug.Log("Attack Monster");

        }

        if (collision.gameObject.CompareTag("Boss") && attackStatus)
        {
            collision.gameObject.GetComponent<Boss>().health.getDamaged(player.GetComponent<Player>().attackDamage / 5);
            collision.gameObject.GetComponent<Boss>().health.isImmune = true;
            collision.gameObject.transform.Find("hitEffect").gameObject.GetComponent<ParticleSystem>().Play();
            //Debug.Log("Attack Monster");

        }


    }
}
