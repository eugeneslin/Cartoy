using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOut : MonoBehaviour
{
    public GameObject plane;

    Vector3 goalPosition;
    public float smoothTime = 1.0f;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        float height = plane.GetComponent<MeshRenderer>().bounds.size.z;
        float width = plane.GetComponent<MeshRenderer>().bounds.size.x;
        float planeSize = Mathf.Max(height, width);

        float fov = Camera.main.fieldOfView;
        float halfFov = fov * 0.5f;
        float distanceToPlane = planeSize / (2.0f * Mathf.Tan(halfFov * Mathf.Deg2Rad));

        goalPosition = new Vector3(plane.transform.position.x, plane.transform.position.y + distanceToPlane, plane.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = goalPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //transform.LookAt(plane.transform);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-plane.transform.up, -plane.transform.forward), 0.02f);
    }
}
