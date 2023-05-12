using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> floors = new List<GameObject>();
    [SerializeField] private List<GameObject> walls = new List<GameObject>();
    [SerializeField] private float[] wallHeightRange = new float[2]; // Hoogte is Y
    [SerializeField] private float[] wallWidthRange = new float[2]; // Wijd is Z
    [SerializeField] private float[] floorHeightRange = new float[2];
    [SerializeField] private float[] floorWidthRange = new float[2];
    [SerializeField] private float[] distanceRange = new float[2];
    [SerializeField] private float spawnDistance;
    [SerializeField] private float removeDistance;
    private List<GameObject> allPlatforms = new List<GameObject>();
    private float lastSpawnPoint;
    private float distanceToNext = 0;
    private int platformRandom = 0;

    void Update()
    {
        
        if(lastSpawnPoint < spawnDistance + player.transform.position.x)
        {
         
            distanceToNext = Random.Range(distanceRange[0], distanceRange[1]);
            platformRandom = 0;//Random.Range(0, 2);
            switch(platformRandom)
            {
                case 0:
                    GameObject spawnedFloors = Instantiate(floors[0]);
                    allPlatforms.Add(spawnedFloors);
                    spawnedFloors.transform.position = new Vector3(lastSpawnPoint = lastSpawnPoint + distanceToNext, Random.Range(floorHeightRange[0], floorHeightRange[1]), Random.Range(floorWidthRange[0], floorWidthRange[1]));
                    break;
                case 1:
                    GameObject spawnedWalls = Instantiate(walls[0]);
                    allPlatforms.Add(spawnedWalls);
                    spawnedWalls.transform.position = new Vector3(lastSpawnPoint = lastSpawnPoint + distanceToNext, Random.Range(wallHeightRange[0], wallHeightRange[1]), Random.Range(wallWidthRange[0], wallWidthRange[1]));
                    break;
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
    }
}
