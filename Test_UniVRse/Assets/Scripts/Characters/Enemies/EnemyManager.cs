using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] BoxCollider spawnArea;

    AreaLimits spawnAreaLimits;

    // Start is called before the first frame update
    void Start()
    {
        spawnAreaLimits = new AreaLimits(spawnArea);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject enemyRef = Instantiate(enemyPrefab, GetRndSpawnPos(), Quaternion.identity, transform);
            EnemyController enemyController = enemyRef.GetComponent<EnemyController>();
            if (enemyController == null)
            {
                Debug.LogError("EnemyController component not found in instanced enemy.");
                return;
            }

            enemyController.SpawnInit(spawnAreaLimits);
        }
    }


    Vector3 GetRndSpawnPos()
    {
        const float SPAWN_HEIGHT = 1.5f;
        Vector3 rndSpawnPos = new Vector3(
            Random.Range(spawnAreaLimits.minX, spawnAreaLimits.maxX),
            SPAWN_HEIGHT,
            Random.Range(spawnAreaLimits.minZ, spawnAreaLimits.maxZ)
        );

        return rndSpawnPos;
    }


}
