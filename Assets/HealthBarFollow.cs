using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour {

	public Transform target;
	public Transform world;
	public Vector3 offsetPosition;
	public Vector3 offsetRotation;

	private Vector3 newPos;

	// Use this for initialization
	void Start () {

		world = GameObject.FindGameObjectWithTag ("World").transform;
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate ();
	}

	// after everything else, adjust camera
	void LateUpdate () {
		// newPos = target.position + offsetPosition;
		newPos = Camera.main.WorldToScreenPoint (target.position);
		// move camera to camera node position
		transform.position = newPos;
		// try to get the same "up" as player


		// transform.rotation = target.rotation;
		// Manuallly adjust x angle
		// transform.Rotate(Vector3.right * xRotation);

		// get gravity direction
		Vector3 gravityDir = (transform.position - world.position).normalized;

		// rotation
		transform.rotation = Quaternion.FromToRotation(transform.up, gravityDir) * transform.rotation;
	}

	void Rotate(){
		transform.LookAt(Camera.main.transform);
	}
}
