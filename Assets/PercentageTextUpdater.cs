using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageTextUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int tilesCleared = TileManager.Instance.tilesTotal - TileManager.Instance.tilesRemaining;
        double percentage = (double)tilesCleared / (double)TileManager.Instance.tilesTotal;
        GetComponent<Text>().text = (percentage * 100).ToString("F0");
    }
}
