using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used to align object to sphereical world

// we need a rigidbody, so throw error if one is not added
[RequireComponent(typeof(Rigidbody))]
public class SphericalGravity : MonoBehaviour {

	// ref variable
	private Rigidbody rb;

	// gravity strength
	[SerializeField]
	private float gravityForce = -9.8f;
	[SerializeField]
	private bool gravity = true;

	Transform world;

	// Use this for initialization
	void Start () {
		world = GameObject.FindGameObjectWithTag ("World").transform;
		// get ref to rigidbody
		rb = GetComponent<Rigidbody> ();
		// turn off default gravity
		rb.useGravity = false;
		// Thanks for nothing mono(always wondered why it's named after a disease)
		// stop rigidbody from setting rotations
		// DUH - not all, just lock rotation
		rb.constraints = RigidbodyConstraints.FreezeRotation; // FreezeAll;
	}

	
	// Update physics here
	void FixedUpdate () {
		// get gravity direction
		Vector3 gravityDir = (transform.position - world.position).normalized;
		// apply gravity to rb
		if(gravity){
			rb.AddForce (gravityDir * gravityForce);
		}

		// rotation
		rb.rotation = Quaternion.FromToRotation(transform.up, gravityDir) * rb.rotation;

	}

}
