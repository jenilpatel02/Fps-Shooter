using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject goon;

    public float timeBetweenEnmySpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenEnmySpawn = 5;
        spawners = new GameObject[5];
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i]=transform.GetChild(i).gameObject;
        }
    }
    private void Update()
    {
        timeBetweenEnmySpawn-=Time.deltaTime;
        if(timeBetweenEnmySpawn<=0)
        {
            spawnenenemy();
            timeBetweenEnmySpawn = 1;
        }
        
    }
    void spawnenenemy()
    { 
        Instantiate(goon, spawners[Random.Range(0, spawners.Length)].transform.position, spawners[Random.Range(0, spawners.Length)].transform.rotation);
    }
}
