using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    [SerializeField] private Transform player;
    private float spawnPos = 0;
    private float tileLenght = 100;
    private int StartTiles = 3;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < StartTiles; i++)
        {
            if (i == 0)
               SpawnTile(0);
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z -60> spawnPos - (StartTiles * tileLenght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward  * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
