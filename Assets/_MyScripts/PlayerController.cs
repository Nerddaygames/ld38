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
	private float turnSpeed = 5f;

	[SerializeField]
	private LayerMask groundLayerMask;

	private Rigidbody rb;

	float groundCheckLength = 2f;
	bool jump;
	bool strafe;

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
		if(Input.GetButton("Jump") && Grounded()){
			Jump();
		}

		// set strafe to false every frame
		strafe = false;

		if(Input.GetButton("Strafe")){
			strafe = true;
		}

	}

	void FixedUpdate(){
		Move ();
	
		// TODO key press for mouse look??
		// Look ();

	}

	bool Grounded(){
		RaycastHit hit;
		Ray ray = new Ray (transform.position, -transform.up);

		// TODO debug remove, DrawRay should take a ray, come on unity!
		// TODO change Vector3.down to -transform.up
		Debug.DrawRay(transform.position, -transform.up * groundCheckLength);


		if (Physics.Raycast (ray, out hit, groundCheckLength, groundLayerMask)) {
			if (hit.collider.tag == "World" || hit.collider.tag == "Ground") {
				return true;
			}
		}
		return false;
	}

	void Move(){
		// transform.Translate (input.x * strafingSpeed, 0, input.y * walkingSpeed);
		// TODO need to move along planet by arc??
		if (strafe) {
			movement = new Vector3 (input.x * strafingSpeed, 0, input.y * walkingSpeed);
			// Better, moves in relation to transform.
			movement = transform.TransformDirection(movement) * Time.deltaTime;
			rb.MovePosition(transform.position + movement);
		} else {
			movement = new Vector3 (0, 0, input.y * walkingSpeed);
			// Better, moves in relation to transform.
			movement = transform.TransformDirection(movement) * Time.deltaTime;
			rb.MovePosition(transform.position + movement);

			/*
			Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
			rb.MoveRotation(rb.rotation * deltaRotation);
			*/
			// rb rotations are froze
			// rb.AddTorque(transform.right * (input.x * turnSpeed * Time.deltaTime));

			transform.Rotate (transform.up * (input.x * turnSpeed * Time.deltaTime));
		}
		// apply movement, doesnt move along world
		// rb.velocity = movement;


	}

	void Look(){
		// TODO add vertical look
		// apply mouse rotation
		// horizontal
		// TODO add clamping
		transform.Rotate(transform.up * rotation.y);
	}

	void Jump(){
		rb.AddForce (transform.up * jumpForce, ForceMode.Impulse);
	}
				
}
