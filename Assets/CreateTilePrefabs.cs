using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTilePrefabs : MonoBehaviour
{
    public GameObject TilePrefab;
    public float TileSpacing = 1.0f;

    void Start()
    {
        Vector3 size = GetComponent<Renderer>().bounds.size;
        Vector3 tileSize = TilePrefab.GetComponent<Renderer>().bounds.size;
        int tileCountX = Mathf.FloorToInt(size.x / tileSize.x);
        int tileCountZ = Mathf.FloorToInt(size.z / tileSize.z);

        for (int x = 0; x < tileCountX; x++)
        {
            for (int z = 0; z < tileCountZ; z++)
            {
                Vector3 pos = new Vector3(x * TileSpacing, 0, z * TileSpacing);
                GameObject tile = Instantiate(TilePrefab, transform.position + pos, Quaternion.identity);
                tile.transform.SetParent(transform);
            }
        }
    }
}
