using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    public Transform BulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float fireRate;
    float nextFire;

    public GameObject Panel;

    public ParticleSystem nuzzleFlash;
    public ParticleSystem Crash;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        } 
    }

    void Shoot() 
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation); 
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * bulletSpeed;
            nuzzleFlash.Play();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("rock")) 
        {
            Destroy(gameObject);
            Instantiate(Crash, transform.position, Quaternion.identity);
            Crash.Play();
            Panel.SetActive(true);
        }

        if (other.collider.CompareTag("cars")) 
        {
            Destroy(gameObject);
            Instantiate(Crash, transform.position, Quaternion.identity);
            Crash.Play();
            Panel.SetActive(true);
        }
    }
}
