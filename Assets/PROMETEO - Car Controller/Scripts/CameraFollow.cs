using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform carTransform;
	public PrometeoCarController carController;

	[Range(1, 10)]
	public float followSpeed = 2;
	[Range(1, 10)]
	public float lookSpeed = 5;
	Vector3 initialCameraPosition;
	Vector3 initialCarPosition;
	Vector3 absoluteInitCameraPosition;
	Quaternion oldRotation = Quaternion.identity;
	Vector3 smoothAcceleration = Vector3.zero;

	void Start(){
		initialCameraPosition = gameObject.transform.position;
		initialCarPosition = carTransform.position;
		absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
	}

	void FixedUpdate()
	{
		if(oldRotation != Quaternion.identity)
        {
			transform.rotation = oldRotation;
        }

		Vector3 target = carTransform.position + carTransform.forward * carController.localVelocityZ;

		//Look at car
		Vector3 _lookDirection = target - transform.position;
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

		//Move to car
		Vector3 _targetPos = absoluteInitCameraPosition + carTransform.transform.position;
		Vector3 _targetPos2 = absoluteInitCameraPosition + target;

		Vector3 screenPos = Camera.main.WorldToScreenPoint(_targetPos);
		Vector3 screenPos2 = Camera.main.WorldToScreenPoint(_targetPos2);

		float distance = Vector3.Distance(screenPos, new Vector3(Screen.width / 2, Screen.height / 2, 0));
		float distance2 = Vector3.Distance(screenPos2, new Vector3(Screen.width / 2, Screen.height / 2, 0));

		if (distance < distance2)
		{
			// _targetPos is closer to the camera
		}
		else
		{
			// _targetPos2 is closer to the camera
			_targetPos = _targetPos2;
		}

		transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);

		// Tilt the camera to counteract the accelerometer

		// Get the accelerometer data with smoothing
		Vector3 rawAcceleration = Input.acceleration;
		smoothAcceleration = Vector3.Lerp(smoothAcceleration, rawAcceleration, 0.25f); // Adjust the smoothing factor as needed

		// Calculate the rotation angle based on the smoothed accelerometer data
		float rotationAngle = Mathf.Atan2(smoothAcceleration.y, smoothAcceleration.x) * Mathf.Rad2Deg;
		rotationAngle += 90;
		rotationAngle = -rotationAngle;

		// Create a new rotation using the original forward direction and the rotation angle
		Quaternion newRotation = Quaternion.AngleAxis(rotationAngle, transform.forward) * Camera.main.transform.rotation;

		oldRotation = transform.rotation;
		transform.rotation = newRotation;

		// HERE
		// Zoom the camera out if the car isn't in the viewport.
		// Otherwise, restore camera zoom to its original level.
	}

}
