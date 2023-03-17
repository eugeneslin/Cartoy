using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDriftingOnTile : MonoBehaviour
{
    private bool isOnPanel = false;
    private bool isDrifting = false;
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tile"))
        {
            isOnPanel = true;
            panel = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tile"))
        {
            isOnPanel = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PrometeoCarController prometeoCarController = GetComponentInParent<PrometeoCarController>();
        isDrifting = prometeoCarController.isDrifting;

        if (panel != null && isOnPanel && isDrifting)
        {
            panel.GetComponent<TileController>().DoDriftDamage();
        }
    }
}