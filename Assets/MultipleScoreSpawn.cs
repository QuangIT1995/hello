using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleScoreSpawn : MonoBehaviour
{
    public GameObject gemPrefab;

    public float spawnInterval = 1.5f;

    public float spawnOffset = 1.0f;

    public float spawnHeight = 10f;

    private float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGem();
            timer = 0;
        }
    }

    void SpawnGem()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), spawnHeight, 0);

        Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
    }
}
