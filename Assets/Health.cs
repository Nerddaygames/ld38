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
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
