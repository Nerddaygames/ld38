using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

// TODO should be pooled

public class PlayerProjectile : MonoBehaviour {
	[SerializeField]
	private float lifeTime= 1f;

	[SerializeField]
	private float speed = 100;

	[SerializeField]
	private int damage = 35;

	[SerializeField]
	private float distance = 50;

	Transform world;

	private Rigidbody rb;
	private Vector3 movement;

	// Use this for initialization
	void Start () {
		world = GameObject.FindGameObjectWithTag ("World").transform;
		rb = GetComponent<Rigidbody> ();
		// rb.AddForce ();
		// rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);

		// lifetime
		Invoke ("OnDestroy", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		// instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));

		// movement = new Vector3(0, 0, speed * Time.deltaTime);
		// rb.MovePosition(transform.position + movement);

		// transform.RotateAround (world.position, Vector3.up * distance, speed * Time.deltaTime);
		transform.RotateAround (world.position, transform.right * distance, speed * Time.deltaTime);

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Enemy")) {
			Debug.Log ("Enemy hit");
			// check for health script
			if (collision.transform.GetComponent<Health> () != null) {
				// decrement health
				collision.transform.GetComponent<Health> ().TakeHealth (damage);
			}
			OnDestroy ();
		}
	}

	// TODO add effects here
	private void OnDestroy(){
		// stop drawing
		MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
		meshRenderer.enabled = false;
		// Destroy after some time for effects
		Destroy (gameObject, 0.5f);
	}

}
