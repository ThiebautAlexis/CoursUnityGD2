using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; 

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnCreature = null;
    [SerializeField] private int spawnCount = 1;
    [SerializeField] private float spawnFrequency = 1.0f;
    [SerializeField] private float spawnRange = 5.0f; 
    private float spawnTimer = 0.0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnFrequency)
            SpawnCreatures(); 
    }

    Vector2 spawnPosition; 
    private void SpawnCreatures()
    {
        spawnTimer = 0f;

        for (int i = 0; i < spawnCount; i++)
        {
            spawnPosition = (Vector2)PlayerController.Instance.transform.position + 
                (new Vector2(Mathf.Cos(Random.Range(-180f, 180f) * Mathf.Deg2Rad), 
                             Mathf.Sin(Random.Range(-180f, 180f) * Mathf.Deg2Rad)
                            ) * spawnRange); 
            Instantiate(spawnCreature, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        if(PlayerController.Instance != null) 
        {
            Gizmos.color = Color.yellow; 
            Gizmos.DrawWireSphere(PlayerController.Instance.transform.position, spawnRange); 
        }
    }
}
