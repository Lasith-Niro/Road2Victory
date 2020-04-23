using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [Header("Road Settings")]
    public GameObject[] roadPrefabs;

    private Transform playerTransform;

    private float animationZone = 15.0f;
    private float spawnZ = -6.0f;
    private float roadLength = 12.0f;
    private int roadssOnScreen = 4;
    private int lastRoadIndex = 0;
    private List<GameObject> activeRoads;
     
    // Start is called before the first frame update
    void Start()
    {
        activeRoads = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < roadssOnScreen; i++)
        {
            if (i < 2)
                SpawnRoad(0);
            else
                SpawnRoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - animationZone > (spawnZ - roadssOnScreen * roadLength))
        {
            SpawnRoad();
            DeleteRoad();
        }
    }
    private void SpawnRoad(int prefabIndex=-1)
    {
        GameObject road;
        if (prefabIndex == -1)
        {
            road = Instantiate(roadPrefabs[RandomRoadIndex()]) as GameObject;
        }
        else
        {
            road = Instantiate(roadPrefabs[prefabIndex]) as GameObject;
        }
        road.transform.SetParent(transform);
        road.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
        activeRoads.Add(road);
    }
    
    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

    private int RandomRoadIndex()
    {
        if (roadPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastRoadIndex;
        while (randomIndex == lastRoadIndex)
        {
            randomIndex = Random.Range(0, roadPrefabs.Length);
        }
        lastRoadIndex = randomIndex;
        return randomIndex;
    }
}
