using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 20.0f;

    public ParticleSystem Crash;

    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("rock")) 
        {
            Destroy(gameObject);
            Instantiate(Crash, transform.position, Quaternion.identity);
            Crash.Play();
        }

        if (other.collider.CompareTag("bullet")) 
        {
            Destroy(gameObject);
            Instantiate(Crash, transform.position, Quaternion.identity);
            Crash.Play();
        }
        
    }
}
