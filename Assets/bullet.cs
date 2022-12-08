using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20;

    private void Start()
    {
        // save it current rotation
        //Quaternion rotation = transform.rotation;
        // Spin it around a random amount
        transform.Rotate(Vector3.forward, Random.Range(0, 360));

    }

    void Update()
    {
        // move it a random amount forward based on it current facing
        transform.position += transform.up * speed;
    }
}
