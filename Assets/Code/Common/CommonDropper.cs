using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CommonDropper : MonoBehaviour {

    public GameObject prefab;

    public float SpawnInterval = .025f;
    public int SpawnBatchCount = 10;
    public int SpawnLimit = 1600;

    private float SpawnCooldown = 0f;
    private int SpawnedPrefabs = 0;

    private EntityManager entityManager;

    private void Start()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();
    }

    private void Update()
    {
        SpawnCooldown -= Time.deltaTime;
        if (SpawnCooldown <= 0f)
        {
            if (GameManager.GetBallCountValue() < SpawnLimit)
            {
                GenerateBatch();
            }
            SpawnCooldown = SpawnInterval;
        }
    }

    private void GenerateBatch()
    {
        for (int i = 0; i < SpawnBatchCount; i++)
        {
            if (GameManager.GetBallCountValue() < SpawnLimit)
            {
                Vector3 randomPos = new Vector3(Random.Range(0, transform.localScale.x) + transform.position.x / 2, transform.position.y, Random.Range(0, transform.localScale.z) + transform.position.z / 2);
                GameObject go = Instantiate(prefab, randomPos, Random.rotation, transform);
                GameManager.IncreateBallCountText();
            }
        }
    }
}
