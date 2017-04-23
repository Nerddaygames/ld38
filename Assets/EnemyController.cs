using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour {

	Rigidbody rb;
	Health health;
	SphericalGravity sphericalGravity;
	// states idle, fleeing, patrolling, attacking, hurt, dead

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		health = GetComponent<Health> ();
		sphericalGravity = GetComponent<SphericalGravity> ();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO better if health script tells us that we are dead than checking every update(requires writting a enemyhealth script)
		if (health.IsAlive () == false) {
			// undo rotation lock set by sphericalgravity script
			rb.constraints = RigidbodyConstraints.None;
			// disable gravity to let them float away.
			/*
			 * Dr. Walter Bishop: Peter, hold on to these tight. Anti-gravity osmium bullets. Shoot Observers with these and watch them float away like balloons.
             * Peter Bishop: If we shoot 'em, they're dead. Why'd we want 'em to float away?
             * Dr. Walter Bishop: ...Because it's cool. 
			 */
			sphericalGravity.enabled = false;
		}
	}
}
