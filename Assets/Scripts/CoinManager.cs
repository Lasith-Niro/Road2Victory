using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    private Transform playerTransform;
    private float spawnZ = -6.0f;
    private float roadLength = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        GameObject coin;
        coin = Instantiate(coinPrefab) as GameObject;

        coin.transform.SetParent(transform);
        coin.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
    }
}
