using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public int numberOfZombiesToSpawn;
    public GameObject[] zombiePrefabs;
    public SpawnerVolume[] spawnVolumes;

    private GameObject followTargetGameObject;

    private bool wave2Spawn = false;
    private bool wave3Spawn = false;


    // Start is called before the first frame update
    void Start()
    {
        followTargetGameObject = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnZombie();
        }

        StartCoroutine(SpawnZombieWaves());
    }


    private void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];

        SpawnerVolume spawnVolume = spawnVolumes[Random.Range(0, spawnVolumes.Length)];

        if (!followTargetGameObject)
        {
            return;
        }

        // Instantiate the random zombie at the random spawn volume
        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().followTarget = followTargetGameObject;
    }


    IEnumerator SpawnZombieWaves()
    {
        yield return new WaitForSeconds(61f);
        GameManager.GetInstance().PromptUser("wave2");
        for (int i = 0; i < numberOfZombiesToSpawn - 4; i++)
        {
            SpawnZombie();
        }
        yield return new WaitForSeconds(61f);
        GameManager.GetInstance().PromptUser("wave3");
        for (int i = 0; i < numberOfZombiesToSpawn - 6; i++)
        {
            SpawnZombie();
        }
    }

}
