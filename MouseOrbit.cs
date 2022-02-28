using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour
{
	//	[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]


	public Transform target;
	public float distance = 5.0f;
	[SerializeField]
	float xSpeed = 5.0f;
	[SerializeField]
	float ySpeed = 5.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float distanceMin = 1.0f;
	public float distanceMax = 15f;

	private Rigidbody rigidbody;

	float x = 0.0f;
	float y = 0.0f;

	private string path;
	private GameObject gameCont;
	public GameObject activePlayer;

	// Use this for initialization


	void Start()
	{
		Time.timeScale = 1;
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		rigidbody = GetComponent<Rigidbody>();

		// Make the rigid body not change rotation
		if (rigidbody != null)
		{
			rigidbody.freezeRotation = true;
		}

		//		Invoke ("FindActivePlayer", 2);
		xSpeed = 20.0f;
		ySpeed = 20.0f;
		distance = 4;
	}



	public void CameraControl (float inputX, float inputY)
	{
		//     Time.timeScale = 1;
		if (target)
		{
	
			x += inputX * xSpeed * distance * 0.02f;
			y -= inputY * ySpeed * 0.02f;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

		//	distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

			/*
			RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) 
			{
				distance -=  hit.distance;
			}*/
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.position;

			transform.rotation = rotation;
			transform.position = new Vector3(position.x, position.y + 2, position.z);
			//       transform.position = position;
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}


}