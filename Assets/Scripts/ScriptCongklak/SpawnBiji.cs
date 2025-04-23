using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBiji : MonoBehaviour
{
    public static SpawnBiji instance;
    [SerializeField] GameObject bijiPrefab;
    [SerializeField] float spacing = 2f;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] int maxSpawn = 7;

    private int spawnCount = 0;
    private bool isSpawning = false;

    private void Awake()
    {
        if (instance != this && instance != null) return;
        instance = this;
    }

    void Start()
    {
        SpawnStart();
        // if (!isSpawning)
        // {
        //     StartCoroutine(BijiSpawn());
        // }
    }

    void SpawnStart()
    {
        for (int i = 0; i < maxSpawn; i++)
        {
            Vector3 offset = Random.insideUnitSphere * 0.36f;
            Instantiate(bijiPrefab, transform.position + offset, Quaternion.identity);
        }
    }

    IEnumerator BijiSpawn()
    {
        isSpawning = true;

        while (true)
        {
            spawnCount = 0;

            for (int i = 0; i < maxSpawn; i++)
            {
                Vector3 spawnPos = transform.position + new Vector3(spacing * spawnCount, 1, 0);
                Instantiate(bijiPrefab, spawnPos, Quaternion.identity);
                spawnCount++;
                
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
