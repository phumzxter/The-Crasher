using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[ ] carPrefabs; 
    public GameObject rockPrefabs;
    private float spawnRangeX = 10; 
    private float spawnPosZ = 400; 
    
    private float startDelay = 2; 
    private float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval); 
    }

    // Update is called once per frame
    void Update()
    {
        int carIndex = Random.Range(0, carPrefabs.Length);
        // Instantiate(carPrefabs[carIndex], new Vector3(5, 0, 0), 
        // carPrefabs[carIndex].transform.rotation);  
    }

    void SpawnRandomCar() 
    { 
        int carIndex = Random.Range(0, carPrefabs.Length); 
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); 
        Instantiate(carPrefabs[carIndex], spawnpos, carPrefabs[carIndex].transform.rotation); 
    } 
    
}
