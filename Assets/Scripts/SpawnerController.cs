using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

   
    public float interval;
    void Start()
    {
        InvokeRepeating("spawn", 0.5f, interval);
    }

    private void spawn()
    {
        int randPos = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randPos].position, Quaternion.identity);
    }


}
