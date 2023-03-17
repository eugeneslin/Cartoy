using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    bool isLevelComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLevelComplete == true)
        {
            return;
        }

        int tilesCleared = TileManager.Instance.tilesTotal - TileManager.Instance.tilesRemaining;
        double percentage = 100f * (double)tilesCleared / (double)TileManager.Instance.tilesTotal;
        if(percentage > 50f)
        {
            // Zoom out camera
            Transform cameraTransform = Camera.main.gameObject.transform; //Find main camera which is part of the scene instead of the prefab
            CameraFollow cameraFollow = cameraTransform.GetComponent<CameraFollow>();
            CameraZoomOut cameraZoomOut = cameraTransform.GetComponent<CameraZoomOut>();
            cameraFollow.enabled = false;
            cameraZoomOut.enabled = true;

            // Hide parking lot
            GameObject parkingZone = GameObject.Find("Parking_Zone");
            parkingZone.SetActive(false);

            // Blow up all other tiles
            TileManager.Instance.BlowUpAllTiles();

            isLevelComplete = true;
        }
    }
}
