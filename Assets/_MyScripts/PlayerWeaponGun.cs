using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponGun : MonoBehaviour {

	private Transform gunPoint;

	// TODO make an array to use multiple ammo types
	public GameObject projectile;
	// time between shots
	public float fireDelta = 0.5F;
	// next time we can shoot
	private float nextFire = 0.5F;
	// use to add targeting to projectile
	private GameObject newProjectile;
	// current time tracker
	private float myTime = 0.0F;

	void Start(){
		gunPoint = GameObject.FindGameObjectWithTag ("GunPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire)
		{
			Shoot ();
		}
	}

	void Shoot(){
		nextFire = myTime + fireDelta;
		newProjectile = Instantiate(projectile, gunPoint.position, transform.rotation) as GameObject;

		// create code here that modifies the newProjectile

		nextFire = nextFire - myTime;
		myTime = 0.0F;
	}
}
