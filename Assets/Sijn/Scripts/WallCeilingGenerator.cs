using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCeilingGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ceiling;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject deathFall;
    [SerializeField] private float[] wallPosition = new float[2];
    [SerializeField] private float ceilingHeight; // Hoogte is Y
    [SerializeField] private float fallHeight;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float spawnDistance;
    [SerializeField] private float removeDistance;
    private List<GameObject> allPlatforms = new List<GameObject>();
    private float lastSpawnPoint;

    void Update()
    {
        if (lastSpawnPoint < spawnDistance + player.transform.position.x)
        {
            GameObject spawnedCeiling = Instantiate(ceiling);
            allPlatforms.Add(spawnedCeiling);
            spawnedCeiling.transform.position = new Vector3(lastSpawnPoint + distanceBetween, ceilingHeight, 0);

            GameObject spawnedWall1 = Instantiate(wall);
            allPlatforms.Add(spawnedWall1);
            spawnedWall1.transform.position = new Vector3(lastSpawnPoint + distanceBetween, wallPosition[0], wallPosition[1]);
            spawnedWall1.transform.rotation = Quaternion.Euler(0, -90, 0);

            GameObject spawnedWall2 = Instantiate(wall);
            allPlatforms.Add(spawnedWall2);
            spawnedWall2.transform.position = new Vector3(lastSpawnPoint = lastSpawnPoint + distanceBetween, wallPosition[0], wallPosition[1] * -1);

            GameObject spawnedDeath = Instantiate(deathFall);
            allPlatforms.Add(spawnedDeath);
            spawnedDeath.transform.position = new Vector3(lastSpawnPoint + distanceBetween, fallHeight, 0);
        }
        for (int i = allPlatforms.Count - 1; 0 <= i; i--)
        {
            if (allPlatforms[i].transform.position.x < player.transform.position.x - removeDistance)
            {
                Destroy(allPlatforms[i]);
                allPlatforms.Remove(allPlatforms[i]);
                break;
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("death");
            Destroy(gameObject);
        }
    }

}
