using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostSpawn : MonoBehaviour
{
    public GameObject speedBoostPrefab;

    public float spawnIntervalMin = 2f;

    public float spawnIntervalMax = 5f;

    public float spawnHeightMin = -3f;

    public float spawnHeightMax = 3f;

    void Start()
    {
        StartCoroutine(SpawnSpeedBoost());
    }

    IEnumerator SpawnSpeedBoost() 
    {
        while (true) 
        {
            float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(spawnInterval);

            float spawnY = Random.Range(spawnHeightMin, spawnHeightMax);
            Vector2 spawnPosition = new Vector2(-Camera.main.orthographicSize * Camera.main.aspect, spawnY);

            Instantiate(speedBoostPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
