using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public int numberOfZombiesToSpawn;
    public GameObject[] zombiePrefabs;
    public SpawnerVolume[] spawnVolumes;

    private GameObject followTargetGameObject;

    // Start is called before the first frame update
    void Start()
    {
        followTargetGameObject = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnZombie();
        }

    }


    private void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];

        SpawnerVolume spawnVolume = spawnVolumes[Random.Range(0, spawnVolumes.Length)];

        if (!followTargetGameObject)
        {
            return;
        }

        // Instantite the random zombie at the random spawn volume
        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().followTarget = followTargetGameObject;
    }
}
