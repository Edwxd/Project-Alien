using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanSpawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public int maxMobCount = 10;
    public float spawnInterval = 120f; // 2 minutes in seconds

    private int currentMobCount = 0;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnMob();
        }
    }

    void SpawnMob()
    {
        if (currentMobCount < maxMobCount)
        {
            Instantiate(mobPrefab, transform.position, Quaternion.identity);
            currentMobCount++;
        }
    }

    public void MobDestroyed()
    {
        currentMobCount--;
    }
}
