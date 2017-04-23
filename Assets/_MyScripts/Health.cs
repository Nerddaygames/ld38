using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {


	[SerializeField]
	private float startingHealth = 100f;

	[SerializeField]
	private float currentHealth;

	private bool hurt;
	private float hurtTime = 60; // measured in frames TODO change to seconds
	private float hurtTimer;

	private bool alive;


	// Use this for initialization
	void Start () {
		alive = true;
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			if(currentHealth <= 0){
				alive = false;
			}
		}
	}

	// used to add health, example is from health pickups
	public void AddHealth(int amount){
		if (alive) {
			currentHealth += amount;
		}
	}

	// used to decrement health, amount meant to be positive
	public void TakeHealth(int amount){
		if (alive) {
			currentHealth -= amount;
		}
	}

	// use for character controller and/or animator
	public bool IsAlive(){
		return alive;
	}
}
