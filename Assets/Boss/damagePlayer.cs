using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{

    private bool damaged = false;
    public bool requireDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !damaged)
        {

                collision.gameObject.transform.Find("heartBrokenEffect").gameObject.GetComponent<ParticleSystem>().Play();
                collision.gameObject.GetComponent<Player>().health.getDamaged(1);
                damaged = true;

            if (requireDestroy) Destroy(gameObject);
        }
    }
}
