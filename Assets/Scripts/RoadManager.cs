using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;

    private Transform playerTransform;

    private float spawnZ = 0.0f;
    private float roadLength = 12.0f;
    private int roadssOnScreen = 7;


     
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i=0; i< roadssOnScreen;i++)
        {
            SpawnRoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void SpawnRoad(int prefabIndex=-1)
    {
        GameObject road;
        road = Instantiate(roadPrefabs[0]) as GameObject;
        road.transform.SetParent(transform);
        road.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
    }
}
