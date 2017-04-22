using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float walkingSpeed = 10f;
	[SerializeField]
	private float strafingSpeed = 50f;

	[SerializeField]
	private float mouseLookSpeedX = 50f;

	[SerializeField]
	private float mouseLookSpeedY = 5f;

	[SerializeField]
	private float jumpForce = 5f;

	[SerializeField]
	private LayerMask groundLayerMask;

	private Rigidbody rb;

	bool grounded;
	bool jump;

	// TODO should this be Vector2??
	private Vector3 input;
	private Vector3 rotation;
	private Vector3 movement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Get Input here
	void Update () {
		input.x = Input.GetAxis ("Horizontal");
		input.y = Input.GetAxis ("Vertical");

		// look left and right
		rotation.y = Input.GetAxis("Mouse X") * mouseLookSpeedX * Time.deltaTime;

		// set jump to false every frame
		jump = false;
		if(Input.GetButton("Jump")){
			Jump();
		}
	}

	void FixedUpdate(){
		Move ();
	
		Look ();

	}

	void Move(){
		// transform.Translate (input.x * strafingSpeed, 0, input.y * walkingSpeed);
		// TODO need to move along planet by arc??
		movement = new Vector3(input.x * strafingSpeed, 0, input.y * walkingSpeed);
		// apply movement, doesnt move along world
		// rb.velocity = movement;

		// Better, moves in relation to transform.
		movement = transform.TransformDirection(movement) * Time.deltaTime;
		rb.MovePosition(transform.position + movement);
	}

	void Look(){
		// apply mouse rotation
		// horizontal
		// TODO add clamping
		//transform.Rotate(transform.up * rotation.y);
	}

	void Jump(){
		rb.AddForce (transform.up * jumpForce, ForceMode.Impulse);
	}
				
}
