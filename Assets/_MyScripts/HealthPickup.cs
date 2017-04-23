using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

// [RequireComponent(typeof(ParticleSystem))]

public class HealthPickup : MonoBehaviour {

	[SerializeField]
	private int amount = 10;

	// to make sure its not picked up twice
	bool pickedUp;

	ParticleSystem particleSystem;

	Light light;
	[SerializeField]
	private float lightMin = 1f;

	[SerializeField]
	private float lightMax = 10f;

	[SerializeField]
	private float strobeSpeed = 10f;

	// Use this for initialization
	void Start () {
		particleSystem = GetComponent<ParticleSystem> ();
		light = GetComponent<Light> ();
		pickedUp = false;
	}

	void Update(){
		if (!pickedUp) {
			// strobe light between min and max
			light.intensity = lightMin + Mathf.PingPong(Time.time * strobeSpeed, (lightMax - lightMin));
		}
	}

	// check for collisions, we only care about the ones from player
	void OnTriggerEnter(Collider other) {
		// check if player already picked this health up
		if (!pickedUp && other.CompareTag ("Player")) {
			// check for health script
			if (other.transform.GetComponent<Health> () != null) {
				// add health to player
				other.transform.GetComponent<Health> ().AddHealth (amount);
				OnDestroy ();
			} else {
				Debug.Log ("Player does not have health script");
			}
		}
	}

	// TODO add effects here
	private void OnDestroy(){
		// toggle pickedUp so can't be pickedUp again
		pickedUp = true;
		// stop drawing
		MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
		meshRenderer.enabled = false;
		// Destroy after some time for effects
		Destroy (gameObject, 0.5f);
	}

}
