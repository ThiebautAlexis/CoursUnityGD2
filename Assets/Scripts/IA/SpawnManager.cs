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

    [SerializeField] private SpawnBehaviour behaviour = SpawnBehaviour.Random; 
    private enum SpawnBehaviour
    {
        Random, 
        Circle
    }

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
        Vector2 _offset; 
        for (int i = 0; i < spawnCount; i++)
        {
            switch (behaviour)
            {
                case SpawnBehaviour.Circle:
                    _offset = GetCirclePosition(i);
                    break;
                default:
                    _offset = GetRandomPosition();
                    break;
            }
            spawnPosition = (Vector2)PlayerController.Instance.transform.position + _offset * spawnRange; 
            Instantiate(spawnCreature, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetCirclePosition(int _currentIndex)
    {
        float _theta = Mathf.Lerp(-180, 180, (float)_currentIndex / spawnCount);
        return new Vector2(Mathf.Cos(_theta), Mathf.Sin(_theta));
    }

    private Vector2 GetRandomPosition()
    {
        float _randomTheta = Random.Range(-180, 180) * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(_randomTheta), Mathf.Sin(_randomTheta));
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
