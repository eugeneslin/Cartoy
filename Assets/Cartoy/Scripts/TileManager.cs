using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject TilePrefab;
    public int tilesRemaining;
    public int tilesTotal;

    private static TileManager instance;

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        Vector3 size = GetComponent<Renderer>().bounds.size;
        Vector3 tileSize = TilePrefab.GetComponent<Renderer>().bounds.size;
        int tileCountX = Mathf.FloorToInt(size.x / tileSize.x);
        int tileCountZ = Mathf.FloorToInt(size.z / tileSize.z);
        float tileSpacingX = size.x / tileCountX;
        float tileSpacingZ = size.z / tileCountZ;
        Vector3 center = transform.position - new Vector3(size.x / 2, 0, size.z / 2);

        for (int x = 0; x < tileCountX; x++)
        {
            for (int z = 0; z < tileCountZ; z++)
            {
                Vector3 pos = new Vector3(x * tileSpacingX, 0, z * tileSpacingZ);
                GameObject tile = Instantiate(TilePrefab, center + pos, Quaternion.identity);
                tilesRemaining++;
            }
        }
        tilesTotal = tilesRemaining;
    }
}