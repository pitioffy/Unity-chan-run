using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] TilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 10f;
    private float tileLength = 10f;
    private float safeZone = 20f;
    private int amountTileOnScreen = 20;
    private List<GameObject> activeTileList;
    private int lastRandomIndex;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTileList = new List<GameObject>();
        for (int i = 0; i < amountTileOnScreen; i++)
        {
            if (i < 3)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (playerTransform.position.z - safeZone > spawnZ - amountTileOnScreen * tileLength)
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject Ground;
        if(prefabIndex == -1)
            Ground = Instantiate(TilePrefabs[RandomIndex()]) as GameObject;
        else
            Ground = Instantiate(TilePrefabs[prefabIndex]) as GameObject;
        Ground.transform.SetParent(transform);
        Ground.transform.position = new Vector3(0, -0.5f, 1 * spawnZ);
        spawnZ += tileLength;
        activeTileList.Add(Ground);
    }

    private void DeleteTile()
    {
        Destroy(activeTileList[0]);
        activeTileList.RemoveAt(0);
    }

    private int RandomIndex()
    {
        if (TilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastRandomIndex;
        while (randomIndex == lastRandomIndex)
        {
            randomIndex = Random.Range(1, TilePrefabs.Length);
        }
        lastRandomIndex = randomIndex;
        return randomIndex;
    }
}
